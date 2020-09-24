using App_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.TrainingGenerator
{
    public class FbwTraining : Chain
    {
        public override List<TrainingExercise> Generate(TrainingParameters trainingParameters, AppDbContext dbContext,Training training)
        {
            if (trainingParameters.trainingType==1)
            {

                List<TrainingExercise> excercises = new List<TrainingExercise>();
                List<Excercise> tmp = new List<Excercise>();
                TrainingExercise trainingExercise = new TrainingExercise();

                //Trening A
                //klata
                Excercise excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 1 && x.Priority==21);
                trainingExercise.Excercise = excercise;
                trainingExercise.DateTime = DateTime.Now;
                trainingExercise.Repeat = 5;
                trainingExercise.Set = 5;
                trainingExercise.Weight = 20.0;
                excercises.Add(trainingExercise);
                tmp.Add(excercise);
                //nogi
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 3 && x.Priority == 1);
                trainingExercise.Excercise = excercise;
                excercises.Add(trainingExercise);
                tmp.Add(excercise);
                //plecy
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 2 && x.Priority == 45 &&x.Machine==trainingParameters.trainingKind);
                trainingExercise.Excercise = excercise;
                excercises.Add(trainingExercise);
                tmp.Add(excercise);
                //Barki
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 7 && x.Priority == 65);
                trainingExercise.Excercise = excercise;
                trainingExercise.Repeat = 8;
                trainingExercise.Set = 3;
                excercises.Add(trainingExercise);
                tmp.Add(excercise);
                //Triceps
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 5 && x.Priority == 84);
                trainingExercise.Excercise = excercise;
                excercises.Add(trainingExercise);
                tmp.Add(excercise);
                //biceps
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 4 && x.Priority == 101);
                trainingExercise.Excercise = excercise;
                excercises.Add(trainingExercise);
                tmp.Add(excercise);
                //brzuch
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 6 && x.Priority == 121);
                trainingExercise.Excercise = excercise;
                excercises.Add(trainingExercise);
                tmp.Add(excercise);
                //dodatkowe
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == trainingParameters.trainingGoal && tmp.FirstOrDefault(y=>y.PrimaryMuscle==trainingParameters.trainingGoal).Priority<x.Priority &&x.Machine==trainingParameters.trainingKind);
                trainingExercise.Excercise = excercise;
                excercises.Add(trainingExercise);

                


                return excercises;
            }
            else
            {
                if(next !=null)
                {
                    return next.Generate(trainingParameters,dbContext,training);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
