using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Test_AmarPC.Areas.DashBoard.Models;

namespace Test_AmarPC.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string JobContent { get; set; }
        public string JobImage { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }

        [Display(Name = "CategoryType")]
        [ForeignKey("Category")]

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public ApplicationUser User { get; set; }
    }
}