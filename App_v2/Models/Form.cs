using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.Models
{
    public class Form
    {
        [Key]
        public int ID { get; set; }

        public AppUser User { get; set; }

        [Column(TypeName = "int")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public int FreeTimeID { get; set; }

        [Column(TypeName = "int")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public int TrainingCategoryID { get; set; }

        [Column(TypeName = "int")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public int GoalID { get; set; }

    }
}
