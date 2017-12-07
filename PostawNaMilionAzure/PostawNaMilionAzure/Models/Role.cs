﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [StringLength(300)]
        public String Name { get; set; }
    }
}