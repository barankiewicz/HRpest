using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRpest.BL.Model;
using HRpest.DAL.Class;
using Microsoft.AspNetCore.Authorization;
using System;

namespace HRpest.APP.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    //[Authorize]
    public class JobOfferController : Controller
    {
        private readonly HrPestContext _context;

        public JobOfferController(HrPestContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery(Name = "search")] string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                return View(await _context.JobOffers.Include(x => x.CreatedFor).ToListAsync());

            List<JobOffer> searchResult = await _context.JobOffers.Include(x => x.CreatedFor).Where(o => o.PositionName.Contains(searchString)).ToListAsync();
            return View(searchResult);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest($"id shouldn't not be null");
            }
            var offer = await _context.JobOffers.Include(x => x.CreatedFor).FirstOrDefaultAsync(x => x.Id == id.Value);
            if (offer == null)
            {
                return NotFound($"offer not found in DB");
            }

            return View(offer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromForm]JobOffer model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var offer = await _context.JobOffers.Include(x => x.CreatedFor).FirstOrDefaultAsync(x => x.Id == model.Id);
            offer.PositionName = model.PositionName;
            _context.Update(offer);
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

            _context.JobOffers.Remove(new JobOffer() { Id = id.Value });
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Create()
        {
            var model = new JobOfferCreateView
            {
                Companies = await _context.Companies.ToListAsync()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm]JobOfferCreateView model)
        {
            if (!ModelState.IsValid)
            {
                model.Companies = await _context.Companies.ToListAsync();
                return View(model);
            }

            JobOffer jo = new JobOffer
            {
                ActiveUntil = model.ActiveUntil,
                CreatedFor = _context.Companies.FirstOrDefault(x=>x.Name == model.CompanyName),
                CreatedBy = model.CreatedBy,
                CreatedOn = DateTime.Now,
                EmploymentType = model.EmploymentType,
                HoursWeekly = model.HoursWeekly,
                JobBenefits = model.JobBenefits,
                JobDescription = model.JobDescription,
                JobRequirements = model.JobRequirements,
                MaximumPay = model.MaximumPay,
                MinimumPay = model.MinimumPay,
                PositionLevel = model.PositionLevel,
                PositionName = model.PositionName,
                RemoteHoursWeekly = model.RemoteHoursWeekly,
                UsualTasks = model.UsualTasks,
                Location = model.Location
            };

            await _context.JobOffers.AddAsync(jo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var offer = await _context.JobOffers.Include(x => x.CreatedFor).FirstOrDefaultAsync(x => x.Id == id);
            return View(offer);
        }

        private bool JobOfferExists(int id)
        {
            return _context.JobOffers.Any(e => e.Id == id);
        }
    }
}
