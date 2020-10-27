using App_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.ViewModel
{
    public class AddHistoryTrainingViewModel
    {
        public List<HistoryTraining> HistoryTrainings { get; set; }

        public TrainingExercise TrainingExercise { get; set; }

        public int SubtrainingId { get; set; }
    }
}
