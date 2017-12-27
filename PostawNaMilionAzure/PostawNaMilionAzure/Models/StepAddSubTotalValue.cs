using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Models
{
    public class StepAddSubTotalValue
    {
        [Key]
        public int Id { get; set; }

        public int StepValue { get; set; }

        public DateTime DateAdd { get; set; }
    }
}