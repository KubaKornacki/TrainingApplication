using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App_v2.Models;

namespace App_v2.TrainingGenerator
{
    public class PushPullTraining : Chain
    {
        public override IEnumerable<TrainingExercise> Generate(TrainingParameters trainingParameters)
        {
            if (trainingParameters.trainingType == 2)
            {
                return null;
            }
            else
            {
                if (next != null)
                {
                    return next.Generate(trainingParameters);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
