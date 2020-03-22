using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Test_AmarPC.Models
{
    public class ApplyForJob
    {
        public int Id { get; set; }
        public string Message { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ApplyDate { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Job")]

        public int JobId { get; set; }
        public Job Job { get; set; }
        public ApplicationUser User { get; set; }
    }
}