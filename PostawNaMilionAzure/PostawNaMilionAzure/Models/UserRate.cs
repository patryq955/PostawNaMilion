using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Models
{
    [Table("UserRate")]
    public class UserRate
    {
        [Key]
        public int Id { get; set; }
        public int GameStepId { get; set; }
        public int RateAnswer1 { get; set; }
        public int RateAnswer2 { get; set; }
        public int RateAnswer3 { get; set; }
        public int RateAnswer4 { get; set; }
    }
}