using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Divisor.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required(ErrorMessage = "The field Name is obligatory")]
        public string? Name { get; set; }

        [ForeignKey("StudentId")]
        public List<Student> StudentList { get; set; } = new List<Student>();
    }
}