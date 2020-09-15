using App_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.TrainingGenerator
{
    public class FbwTraining : Chain
    {
        public override IEnumerable<TrainingExercise> Generate(TrainingParameters trainingParameters)
        {
            if (trainingParameters.trainingType==1)
            {
                return null;
            }
            else
            {
                if(next !=null)
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
