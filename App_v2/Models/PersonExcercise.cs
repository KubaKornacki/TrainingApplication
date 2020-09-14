using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.Models
{
    public class PersonExcercise
    {
        [Key]
        public int ID { get; set; }

        public AppUser AppUser { get; set; }

        public Excercise Excercise { get; set; }


        public double Max { get; set; }

        public double Progress { get; set; }
    }
}
