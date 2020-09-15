using App_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.TrainingGenerator
{
    interface IChain
    {
        void Next(Chain chain);

        IEnumerable<TrainingExercise> Generate(TrainingParameters trainingParameters);
    }
}
