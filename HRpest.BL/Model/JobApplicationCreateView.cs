using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web;

namespace HRpest.BL.Model
{
    public class JobApplicationCreateView : JobApplication
    {
        public int JobOfferId { get; set; }

        [Display(Name = "CV File:")]
        //[FileExtensions(Extensions = "pdf,doc,docx")]
        public IFormFile CvFile { get; set; }
    }
}
