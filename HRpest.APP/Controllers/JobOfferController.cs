using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRpest.BL.Model;
using HRpest.DAL.Class;
using Microsoft.AspNetCore.Authorization;
using System;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.ComponentModel.DataAnnotations;
using HRpest.BL.Helpers;

namespace HRpest.APP.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    [Authorize]
    public class JobOfferController : Controller
    {
        private readonly HrPestContext _context;
        private readonly IConfiguration _configuration;

        private enum EmailType
        {
            [Display(Name = "created")]
            CREATED,
            [Display(Name = "edited")]
            EDITED,
            [Display(Name = "deleted")]
            DELETED
        };

        public JobOfferController(HrPestContext context, IConfiguration conf)
        {
            _context = context;
            _configuration = conf;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery(Name = "search")] string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                return View(await _context.JobOffers.Include(x => x.CreatedFor).ToListAsync());

            List<JobOffer> searchResult = await _context.JobOffers.Include(x => x.CreatedFor).Where(o => o.PositionName.Contains(searchString)).ToListAsync();
            return View(searchResult);
        }

        [HttpGet]
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

            offer.ActiveUntil = model.ActiveUntil;
            offer.EmploymentType = model.EmploymentType;
            offer.HoursWeekly = model.HoursWeekly;
            offer.JobBenefits = model.JobBenefits;
            offer.JobDescription = model.JobDescription;
            offer.JobRequirements = model.JobRequirements;
            offer.MaximumPay = model.MaximumPay;
            offer.MinimumPay = model.MinimumPay;
            offer.PositionLevel = model.PositionLevel;
            offer.PositionName = model.PositionName;
            offer.RemoteHoursWeekly = model.RemoteHoursWeekly;
            offer.UsualTasks = model.UsualTasks;
            offer.Location = model.Location;

            offer.EditedOn = DateTime.Now;
            _context.Update(offer);
            await _context.SaveChangesAsync();
            await PostMessage(EmailType.EDITED, offer);
            return RedirectToAction("Details", new { id = model.Id });
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest($"id should not be null");
            }
            var toDelete = _context.JobApplications.Where(x => x.JobOffer.Id == id).ToList();

            _context.JobApplications.RemoveRange(toDelete);
            var jo = _context.JobOffers.Include(x=>x.CreatedFor).FirstOrDefault(x => x.Id == id.Value);
            await PostMessage(EmailType.DELETED, jo);
            _context.JobOffers.Remove(jo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
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
                CreatedFor = _context.Companies.FirstOrDefault(x => x.Id == Int32.Parse(model.CompanyName)),
                CreatedByEmail = User.Claims.Where(c => c.Type == "emails").Select(c => c.Value).SingleOrDefault(),
                CreatedBy = model.CreatedBy,
                CreatedOn = DateTime.Now,
                EditedOn = DateTime.Now,
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

            await PostMessage(EmailType.CREATED, jo);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var offer = await _context.JobOffers.Include(x => x.CreatedFor).FirstOrDefaultAsync(x => x.Id == id);
            return View(offer);
        }

        private async Task PostMessage(EmailType type, JobOffer jo)
        {
            var mail = User.Claims.Where(c => c.Type == "emails")
                   .Select(c => c.Value).SingleOrDefault();
            var apiKey = _configuration.GetSection("SendGridApiKey").Value;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("mail@hrpest.com", "HRpest");
            var to = new EmailAddress(mail, User.Identity.Name);


            var subject = "You " + EnumHelper.GetDisplayName(type) + " a Job Offer!";
            var htmlContent = "<strong>You "+ EnumHelper.GetDisplayName(type) + " a Job Offer: <br/> " + jo.PositionName + " at " + jo.CreatedFor.Name + "<br/>on " + DateTime.Now.ToString() + "</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
