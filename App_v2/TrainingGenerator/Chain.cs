using App_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.TrainingGenerator
{
    public abstract class Chain : IChain
    {
        protected Chain next;

        public void SetNext(Chain chain)
        {
            next = chain;
        }

        public abstract List<TrainingExercise> Generate(TrainingParameters trainingParameters, AppDbContext dbContext,Training training);

        public void Next(Chain chain)
        {
            next = chain;
        }
    }
}
