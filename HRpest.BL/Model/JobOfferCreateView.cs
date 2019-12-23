using System;
using System.Collections.Generic;
using System.Text;

namespace HRpest.BL.Model
{
    public class JobOfferCreateView : JobOffer
    {
        public IEnumerable<Company> Companies { get; set; }
        public string CompanyName { get; set; }
    }
}
