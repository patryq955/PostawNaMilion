using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Models
{
    [Table("Question")]
    public class Question
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj Treść pytania")]
        [StringLength(300)]
        [Display(Name = "Pytanie")]
        public String Contents { get; set; }

        [Display(Name = "Poziom trudności")]
        public Level Level { get; set; }

        [Display(Name = "Kategoria")]
        public int CategoryDictId { get; set; }
        public bool IsHidden { get; set; }

        public virtual ICollection<Answer> Answer { get; set; }
    }

    public enum Level : int
    {
        easy = 1,
        harh = 2
    }
}