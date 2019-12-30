using System;
using System.Collections.Generic;
using System.Text;

namespace HRpest.BL.Model
{
    public class CompanyPagingViewModel
    {
        public IEnumerable<Company> Companies { get; set; }
        public int TotalPage { get; set; }
    }
}
