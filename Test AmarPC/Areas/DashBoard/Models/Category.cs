using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test_AmarPC.Models;

namespace Test_AmarPC.Areas.DashBoard.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }

    }
}