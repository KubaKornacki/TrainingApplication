using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.Models
{
    public class Excercise
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "Pole wymagane")]
        public string Name { get; set; }

        [Column(TypeName = "int")]
        public int Priority { get; set; }

        [Column(TypeName = "nvarchar(Max)")]
        public string Description { get; set; }

        [Column(TypeName = "int")]
        public int PrimaryMuscle { get; set; }


        public bool Dynamic { get; set; }

    }
}
