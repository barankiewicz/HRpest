using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRpest.BL.Model;
using HRpest.DAL.Class;
using Microsoft.AspNetCore.Authorization;

namespace HRpest.APP.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    //[Authorize]
    public class JobApplicationController : Controller
    {
        private readonly HrPestContext _context;

        public JobApplicationController(HrPestContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery(Name = "search")] string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                return View(await _context.JobApplications.Include(x => x.JobOffer).ThenInclude(x => x.CreatedFor).Include(x => x.Applicant).ToListAsync());

            List<JobApplication> searchResult = await _context.JobApplications.Include(x => x.JobOffer).ThenInclude(x => x.CreatedFor).Include(x=>x.Applicant).Where(o => o.Applicant.Name.Contains(searchString)).ToListAsync();
            return View(searchResult);
        }

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

            return View(application);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromForm]JobApplication model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var application = await _context.JobApplications.Include(x => x.JobOffer).ThenInclude(x => x.CreatedFor).Include(x => x.Applicant).FirstOrDefaultAsync(x => x.Id == model.Id);

            application.CvHandle = model.CvHandle;
            application.AdditionalInformation = model.AdditionalInformation;
            application.ApplicationStatus = model.ApplicationStatus;
            application.EditedOn = DateTime.Now;

            _context.Update(application);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = model.Id });
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest($"id should not be null");
            }

            _context.JobApplications.Remove(new JobApplication() { Id = id.Value });
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

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
                CreatedOn = DateTime.Now,
                CvHandle = model.CvHandle,
                DeletedOn = null,
                EditedOn = DateTime.Now,
                JobOffer = offer
            };

            await _context.JobApplications.AddAsync(ja);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

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

        // GET: JobApplication/GetJobApplications?jobOfferId=5
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<JobApplication>>> GetJobApplications([FromQuery]int jobOfferId, [FromQuery]string name = null)
        //{
        //    if (jobOfferId == 0) return null;
        //    var jobapps = await _context.JobApplications.Include(x => x.Applicant).Include(x => x.JobOffer).Where(x => x.JobOffer.Id == jobOfferId).ToListAsync();

        //    if (name == null)
        //        return jobapps;
        //    else
        //        return Ok(jobapps.Where(x => x.Applicant.FullName.ToLower().Contains(name.ToLower())));
        //}

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

        private bool JobApplicationExists(int id)
        {
            return _context.JobApplications.Any(e => e.Id == id);
        }
    }
}
