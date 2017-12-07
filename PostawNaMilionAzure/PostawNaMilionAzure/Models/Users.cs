using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public String Surname { get; set; }
        [StringLength(300)]
        public String Name { get; set; }
        [StringLength(20)]
        public String Login { get; set; }
        [StringLength(100)]
        public String Password { get; set; }
        [StringLength(100)]
        public String Address { get; set; }
        [StringLength(50)]
        public String City { get; set; }
        public int RoleId { get; set; }
        public bool IsAtive { get; set; }
        
    }
}