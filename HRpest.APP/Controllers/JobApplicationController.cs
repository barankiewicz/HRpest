﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRpest.BL.Model;
using HRpest.DAL.Class;
using Microsoft.AspNetCore.Authorization;
using HRpest.BL.Helpers;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using HRpest.APP.Helpers;

namespace HRpest.APP.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    //[Authorize]
    public class JobApplicationController : Controller
    {
        private readonly HrPestContext _context;
        IWebHostEnvironment env;

        public JobApplicationController(HrPestContext context, IWebHostEnvironment _env)
        {
            _context = context;
            env = _env;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest($"id shouldn't not be null");
            }
            var application = await _context.JobApplications.Include(x => x.JobOffer).ThenInclude(x => x.CreatedFor).Include(x => x.Applicant).FirstOrDefaultAsync(x => x.Id == id.Value);
            if (application == null)
            {
                return NotFound($"offer not found in DB");
            }

            return View(new JobApplicationCreateView()
            {
                AdditionalInformation = application.AdditionalInformation,
                Applicant = application.Applicant,
                ApplicationStatus = application.ApplicationStatus,
                ApplicationStatusText = application.ApplicationStatusText,
                CreatedOn = application.CreatedOn,
                CvHandle = application.CvHandle,
                DeletedOn = application.DeletedOn,
                EditedOn = application.EditedOn,
                Id = application.Id,
                JobOffer = application.JobOffer,
                JobOfferId = application.JobOffer.Id
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromForm]JobApplicationCreateView model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var application = await _context.JobApplications.Include(x => x.JobOffer).ThenInclude(x => x.CreatedFor).Include(x => x.Applicant).FirstOrDefaultAsync(x => x.Id == model.Id);

            if(model.CvFile != null)
                DeleteCvFromStorage(application.CvHandle);

            application.CvHandle = UploadCvToStorage(model);
            application.AdditionalInformation = model.AdditionalInformation;
            application.ApplicationStatus = model.ApplicationStatus;
            application.ApplicationStatusText = EnumHelper.GetDisplayName(model.ApplicationStatus);
            application.EditedOn = DateTime.Now;

            _context.Update(application);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = model.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest($"id should not be null");
            }

            var application = await _context.JobApplications.FirstOrDefaultAsync(x => x.Id == id);

            DeleteCvFromStorage(application.CvHandle);

            _context.JobApplications.Remove(new JobApplication() { Id = id.Value });
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Create(int? id)
        {
            if (id == null)
            {
                return BadRequest($"id shouldn't not be null");
            }
            var offer = await _context.JobOffers.Include(x => x.CreatedFor).FirstOrDefaultAsync(x => x.Id == id.Value);

            var model = new JobApplicationCreateView()
            {
                JobOffer = offer,
                JobOfferId = offer.Id
            };

            if (offer == null)
            {
                return NotFound($"offer not found in DB");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm]JobApplicationCreateView model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Name == "Filip");
            var offer = await _context.JobOffers.Include(x => x.CreatedFor).FirstOrDefaultAsync(x => x.Id == model.JobOfferId);

            if (offer == null)
            {
                return NotFound($"offer not found in DB");
            }

            JobApplication ja = new JobApplication
            {
                AdditionalInformation = model.AdditionalInformation,
                Applicant = user,
                ApplicationStatus = BL.Enum.ApplicationStatus.NO_DECISION_MADE,
                ApplicationStatusText = EnumHelper.GetDisplayName(BL.Enum.ApplicationStatus.NO_DECISION_MADE),
                CreatedOn = DateTime.Now,
                CvHandle = UploadCvToStorage(model),
                DeletedOn = null,
                EditedOn = DateTime.Now,
                JobOffer = offer
            };

            await _context.JobApplications.AddAsync(ja);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "JobApplication", new { jobOfferId = offer.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var offer = await _context.JobApplications.Include(x => x.JobOffer).ThenInclude(x=>x.CreatedFor).Include(x => x.Applicant).FirstOrDefaultAsync(x => x.Id == id);
            return View(offer);
        }


        [HttpGet]
        public JobApplicationPagingViewModel GetJobApplications([FromQuery]int jobOfferId, [FromQuery]string name = null, [FromQuery]int pageNo = 1, [FromQuery]int pageSize = 3)
        {
            if (jobOfferId == 0) return null;
            var jobapps = _context.JobApplications.Include(x => x.Applicant).Include(x => x.JobOffer).Where(x => x.JobOffer.Id == jobOfferId).ToList();
            if (name != null && name.Trim() != "")
                jobapps = jobapps.Where(x => x.Applicant.FullName.ToLower().Contains(name.ToLower())).ToList();

            int totalPage, totalRecord;

            totalRecord = jobapps.Count();
            totalPage = (totalRecord / pageSize) + ((totalRecord % pageSize) > 0 ? 1 : 0);
            var record = jobapps.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

            JobApplicationPagingViewModel empData = new JobApplicationPagingViewModel
            {
                JobApplications = record,
                TotalPage = totalPage
            };

            return empData;
        }

        // GET: JobApplication/GetJobApplication/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobApplication>> GetJobApplication(int id)
        {
            var jobApplication = await _context.JobApplications.FindAsync(id);

            if (jobApplication == null)
            {
                return NotFound();
            }

            return Ok(jobApplication);
        }

        [HttpPost]
        public async Task<ActionResult<JobApplication>> PostJobApplication([Bind("CvFile")] JobApplicationCreateView jobApplication)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Name == "Filip");
            var offer = await _context.JobOffers.Include(x => x.CreatedFor).FirstOrDefaultAsync(x => x.Id == jobApplication.JobOfferId);

            var files = HttpContext.Request.Form.Files;
            if (offer == null)
            {
                return NotFound($"offer not found in DB");
            }

            JobApplication ja = new JobApplication
            {
                AdditionalInformation = jobApplication.AdditionalInformation,
                Applicant = user,
                ApplicationStatus = BL.Enum.ApplicationStatus.NO_DECISION_MADE,
                ApplicationStatusText = EnumHelper.GetDisplayName(BL.Enum.ApplicationStatus.NO_DECISION_MADE),
                CreatedOn = DateTime.Now,
                CvHandle = UploadCvToStorage(jobApplication),
                DeletedOn = null,
                EditedOn = DateTime.Now,
                JobOffer = offer
            };

            await _context.JobApplications.AddAsync(ja);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobApplication", new { id = jobApplication.Id }, jobApplication);
        }

        private string UploadCvToStorage(JobApplicationCreateView model)
        {
            var uploads = Path.Combine(env.WebRootPath, "uploads");
            bool exists = Directory.Exists(uploads);
            if (!exists)
                Directory.CreateDirectory(uploads);

            var fileName = Path.GetFileName(model.CvFile.FileName);
            var fileStream = new FileStream(Path.Combine(uploads, model.CvFile.FileName), FileMode.Create);
            string mimeType = model.CvFile.ContentType;
            byte[] fileData = new byte[model.CvFile.Length];

            BlobStorageHelper objBlobService = new BlobStorageHelper();

            return objBlobService.UploadFileToBlob(model.CvFile.FileName, fileData, mimeType);
        }

        private void DeleteCvFromStorage(string uri)
        {
            if(uri != null && uri != "")
            {
                BlobStorageHelper objBlobService = new BlobStorageHelper();
                objBlobService.DeleteBlobData(uri);
            }

            return;
        }

    }
}
