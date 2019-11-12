using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRpest.BL.Model;
using HRpest.DAL.Class;
using Microsoft.AspNetCore.Authorization;

namespace HRpest.APP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class JobOfferController : Controller
    {
        private readonly HrPestContext _context;

        public JobOfferController(HrPestContext context)
        {
            _context = context;
        }

        [Route("index")]
        public IActionResult Index()
        {
            return View(_context.JobOffers.ToList());
        }
        public IActionResult Details(int id)
        {
            var offer = _context.JobOffers.FirstOrDefault(o => o.Id == id);
            return View(offer);
        }

        //// GET: api/JobOffers
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<JobOffer>>> GetJobOffers()
        //{
        //    return await _context.JobOffers.ToListAsync();
        //}

        //// GET: api/JobOffers/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<JobOffer>> GetJobOffer(int id)
        //{
        //    var jobOffer = await _context.JobOffers.FindAsync(id);

        //    if (jobOffer == null)
        //    {
        //        return NotFound();
        //    }

        //    return jobOffer;
        //}

        // PUT: api/JobOffers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobOffer(int id, JobOffer jobOffer)
        {
            if (id != jobOffer.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobOffer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobOfferExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/JobOffers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<JobOffer>> PostJobOffer(JobOffer jobOffer)
        {
            _context.JobOffers.Add(jobOffer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobOffer", new { id = jobOffer.Id }, jobOffer);
        }

        // DELETE: api/JobOffers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JobOffer>> DeleteJobOffer(int id)
        {
            var jobOffer = await _context.JobOffers.FindAsync(id);
            if (jobOffer == null)
            {
                return NotFound();
            }

            _context.JobOffers.Remove(jobOffer);
            await _context.SaveChangesAsync();

            return jobOffer;
        }

        private bool JobOfferExists(int id)
        {
            return _context.JobOffers.Any(e => e.Id == id);
        }
    }
}
