using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.Models
{
    public class Training
    {
        public int ID { get; set; }

        public string TrainingName { get; set; }

        public AppUser AppUser { get; set; }

        public bool Active { get; set; }


    }
}
