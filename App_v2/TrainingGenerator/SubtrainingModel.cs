
using App_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.TrainingGenerator
{
    public class SubtrainingModel
    {
        public Subtraining Subtraining { get; set; }

        public List<TrainingExercise> TrainingExercises { get; set; }
    }
}
