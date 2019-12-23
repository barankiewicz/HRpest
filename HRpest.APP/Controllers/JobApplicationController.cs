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
                return View(await _context.JobApplications.Include(x => x.JobOffer).ToListAsync());

            List<JobApplication> searchResult = await _context.JobApplications.Include(x => x.JobOffer).Where(o => o.Applicant.Name.Contains(searchString)).ToListAsync();
            return View(searchResult);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest($"id shouldn't not be null");
            }
            var offer = await _context.JobApplications.Include(x => x.JobOffer).FirstOrDefaultAsync(x => x.Id == id.Value);
            if (offer == null)
            {
                return NotFound($"offer not found in DB");
            }

            return View(offer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromForm]JobApplication model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var application = await _context.JobApplications.Include(x => x.JobOffer).FirstOrDefaultAsync(x => x.Id == model.Id);
            
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

            _context.JobApplications.Remove(new JobApplication() { Id = id.Value });
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Create(int id)
        {
            var model = new JobApplication()
            {
                JobOffer = _context.JobOffers.FirstOrDefault(x => x.Id == id)
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm]JobApplication model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            JobApplication ja = new JobApplication
            {
                AdditionalInformation = model.AdditionalInformation,
                Applicant = model.Applicant,
                ApplicationStatus = BL.Enum.ApplicationStatus.NO_DECISION_MADE,
                CreatedOn = DateTime.Now,
                CvHandle = model.CvHandle,
                DeletedOn = null,
                EditedOn = DateTime.Now,
                JobOffer = model.JobOffer
            };

            await _context.JobApplications.AddAsync(ja);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var offer = await _context.JobApplications.Include(x => x.JobOffer).FirstOrDefaultAsync(x => x.Id == id);
            return View(offer);
        }

        private bool JobApplicationExists(int id)
        {
            return _context.JobApplications.Any(e => e.Id == id);
        }
    }
}
