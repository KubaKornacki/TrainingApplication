using App_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.TrainingGenerator
{
    public class TrainingParameters
    {
        public TrainingParameters(Training training,int type,int goal,int category,int freeTime,int kind)
        {
            this.training = training;
            trainingType = type;
            trainingGoal = goal;
            trainingCategory = category;
            trainingFreeTime = freeTime;
            if (kind == 2)
                trainingKind = true;
            else
                trainingKind = false;
        }


        public Training training { get; set; }
        public int trainingType { get; set; }
        public bool trainingKind { get; set; }
        public int trainingGoal { get; set; }
        public int trainingCategory { get; set; }
        public int trainingFreeTime { get; set; }
    }
}
