using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.Models
{
    public class Subtraining
    {
        public int ID { get; set; }

        public string  Name { get; set; }

        public Training Training { get; set; }
    }
}
