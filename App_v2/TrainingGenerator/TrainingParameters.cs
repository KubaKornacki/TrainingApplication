using App_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.TrainingGenerator
{
    public class TrainingParameters
    {
        public TrainingParameters(Training training,int type,int goal,int category,int freeTime,int kind,IEnumerable<Dict> isolation)
        {
            this.training = training;
            trainingType = type;
            trainingGoal = goal;
            //trainingCategory = category;
            trainingFreeTime = freeTime;
            if (kind == 2)
                trainingKind = true;
            else
                trainingKind = false;
            Dict value = new Dict();
            Dict valueIsolated = new Dict();
            if(category==1)
            {
                 valueIsolated = isolation.FirstOrDefault(x => x.textValue== "strength-isolated");
                 value = isolation.FirstOrDefault(x => x.textValue == "strength");
                isolatedReps = valueIsolated.intValue;
                isolatedSets = Convert.ToInt32(valueIsolated.decimalValue);
                Reps = value.intValue;
                Sets= Convert.ToInt32(value.decimalValue);
            }
            else if(category==2)
            {
                valueIsolated = isolation.FirstOrDefault(x => x.textValue == "endurance-isolated");
                value = isolation.FirstOrDefault(x => x.textValue == "endurance");
                isolatedReps = valueIsolated.intValue;
                isolatedSets = Convert.ToInt32(valueIsolated.decimalValue);
                Reps = value.intValue;
                Sets = Convert.ToInt32(value.decimalValue);
            }
            else
            {
                valueIsolated = isolation.FirstOrDefault(x => x.textValue == "power-isolated");
                value = isolation.FirstOrDefault(x => x.textValue == "power");
                isolatedReps = valueIsolated.intValue;
                isolatedSets = Convert.ToInt32(valueIsolated.decimalValue);
                Reps = value.intValue;
                Sets = Convert.ToInt32(value.decimalValue);
            }
        }


        public Training training { get; set; }
        public int trainingType { get; set; }
        public bool trainingKind { get; set; }
        public int trainingGoal { get; set; }
        public int trainingCategory { get; set; }
        public int trainingFreeTime { get; set; }
        public int isolatedReps { get; set; }
        public int isolatedSets { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
    }
}
