using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Models
{
    [Table("Answer")]
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        public int QuestionId { get; set; }

        [StringLength(300)]
        [Display(Name = "Odpowiedź")]
        [Required(ErrorMessage = "Podaj treść Pytania")]
        public String Contents { get; set; }

        [Display (Name = "Prawidłowa odpowiedź")]
        public bool IsCorrect { get; set; }

    }
}