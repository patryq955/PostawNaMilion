using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Models
{
    [Table("Game")]
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public int StageEnd{ get; set; }
        public float Balance { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}