using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRpest.BL.Model;
using HRpest.DAL.Class;

namespace HRpest.APP.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly HrPestContext _context;

        public CompanyController(HrPestContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery(Name = "search")] string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                return View(await _context.Companies.ToListAsync());

            List<Company> searchResult = await _context.Companies.Where(o => o.Name.ToLower().Contains(searchString.ToLower())).ToListAsync();
            return View(searchResult);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest($"id shouldn't not be null");
            }
            var application = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id.Value);
            if (application == null)
            {
                return NotFound($"offer not found in DB");
            }

            return View(application);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromForm]Company model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == model.Id);

            company.Name = model.Name;
            company.NumberOfEmployees = model.NumberOfEmployees;
            company.Description = model.Description;
            company.Location = model.Location;
            company.EditedOn = DateTime.Now;
            company.DefaultNumberOfRemoteHoursWeekly = model.DefaultNumberOfRemoteHoursWeekly;
            company.DefaultNumberOfHoursWeekly = model.DefaultNumberOfHoursWeekly;
            company.DefaultEmploymentType = model.DefaultEmploymentType;

            _context.Update(company);
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

            _context.Companies.Remove(new Company() { Id = id.Value });
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {

            var model = new Company();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm]Company model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Company ja = new Company
            {
                Description = model.Description,
                Location = model.Location,
                Name = model.Name,
                NumberOfEmployees = model.NumberOfEmployees,
                CreatedOn = DateTime.Now,
                EditedOn = DateTime.Now,
                DefaultEmploymentType = model.DefaultEmploymentType,
                DefaultNumberOfHoursWeekly = model.DefaultNumberOfHoursWeekly,
                DefaultNumberOfRemoteHoursWeekly = model.DefaultNumberOfRemoteHoursWeekly
            };

            await _context.Companies.AddAsync(ja);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
            return View(company);
        }

        //API METHODS

        // GET: api/Company
        [HttpGet]
        public CompanyPagingViewModel GetCompanies([FromQuery]string name = null, [FromQuery]int pageNo = 1, [FromQuery]int pageSize = 3)
        {
            var companies = _context.Companies.ToList();
            if (name != null && name.Trim() != "")
                companies = companies.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();

            int totalPage, totalRecord;

            totalRecord = companies.Count();
            totalPage = (totalRecord / pageSize) + ((totalRecord % pageSize) > 0 ? 1 : 0);
            var record = companies.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

            CompanyPagingViewModel empData = new CompanyPagingViewModel
            {
                Companies = record,
                TotalPage = totalPage
            };

            return empData;
        }

        // GET: api/Company/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        [HttpPost]
        public async Task<ActionResult<JobApplication>> PostCompany(Company company)
        {

            Company ja = new Company
            {
                Description = company.Description,
                Location = company.Location,
                Name = company.Name,
                NumberOfEmployees = company.NumberOfEmployees,
                CreatedOn = DateTime.Now,
                EditedOn = DateTime.Now,
                DefaultEmploymentType = company.DefaultEmploymentType,
                DefaultNumberOfHoursWeekly = company.DefaultNumberOfHoursWeekly,
                DefaultNumberOfRemoteHoursWeekly = company.DefaultNumberOfRemoteHoursWeekly
            };

            await _context.Companies.AddAsync(ja);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = company.Id }, company);
        }
    }
}
