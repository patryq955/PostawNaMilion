using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Models
{
    [Table("CategoryDict")]
    public class CategoryDict
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [Display(Name = "Nazwa")]
        [StringLength(300)]
        public String Name { get; set; }

        [Required(ErrorMessage = "Opis jest wymagany")]
        [Display(Name = "Opis")]
        [StringLength(300)]
        public String Description { get; set; }

        [Display (Name = "Zakres")]
        public int KnowledgeAreaId { get; set; }

        public bool IsHidden { get; set; }
    }
}