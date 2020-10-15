using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.Models
{
    public class HistoryTraining
    {

        public int ID { get; set; }

        public DateTime CreateDatetime { get; set; }

        public int SetN { get; set; }

        public int Repeats { get; set; }

        public Double Weight { get; set; }

        public TrainingExercise TrainingExercise { get; set; }
    }
}
