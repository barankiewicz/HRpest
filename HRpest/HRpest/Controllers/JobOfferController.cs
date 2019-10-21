using System.Collections.Generic;
using System.Linq;
using HRpest.Models;
using Microsoft.AspNetCore.Mvc;

namespace HRpest.Controllers
{
	[Route("[controller]")]
	public class JobOfferController : Controller
	{
		private static List<JobOffer> _jobOffers = new List<JobOffer>
		{
			new JobOffer{Id=1, JobTitle= "Backend Developer" },
			new JobOffer{Id=1, JobTitle= "Frontend Developer" },
			new JobOffer{Id=1, JobTitle= "Manager" },
			new JobOffer{Id=1, JobTitle= "Cook" }
		};

		[Route("index")]
		public IActionResult Index()
		{
			return View(_jobOffers);
		}
		public IActionResult Details(int id)
		{
			var offer = _jobOffers.FirstOrDefault(o => o.Id == id);
			return View(offer);
		}

	}
}