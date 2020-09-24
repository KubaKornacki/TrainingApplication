using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.Models
{
    public class TrainingExercise
    {
        public int ID { get; set; }

        public Subtraining Subtraining { get; set; }

        public Excercise Excercise { get; set; }

        public int Set { get; set; }

        public int Repeat { get; set; }

        public double Weight { get; set; }

        public DateTime DateTime { get; set; }
    }
}
