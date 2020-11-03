using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App_v2.Models;
using App_v2.Tools;

namespace App_v2.TrainingGenerator
{
    public class PushPullTraining : Chain
    {
        public override List<TrainingExercise> Generate(TrainingParameters trainingParameters, AppDbContext dbContext,Training training)
        {
            if (trainingParameters.trainingType == 2)
            {
                List<TrainingExercise> excercises = new List<TrainingExercise>();
                List<Excercise> tmp = new List<Excercise>();

                //Trening A
                Subtraining subtraining1 = new Subtraining();
                subtraining1.Name = "Push";
                subtraining1.Training = training;
                //nogi
                Excercise excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 3 && x.Priority == 1 && trainingParameters.trainingKind==x.Machine);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, trainingParameters, 20.0, subtraining1));
                tmp.Add(excercises.Last().Excercise);
                //klata
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 1 && x.Priority == 21);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, trainingParameters, 20.0, subtraining1));
                tmp.Add(excercises.Last().Excercise);
                //barki
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 7 && x.Priority == 61 && trainingParameters.trainingKind == x.Machine);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, trainingParameters, 10.0, subtraining1));
                tmp.Add(excercises.Last().Excercise);
                //triceps
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 5 && x.Priority == 83);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, trainingParameters, 6.0, subtraining1));
                tmp.Add(excercises.Last().Excercise);
                if(trainingParameters.trainingGoal==1|| trainingParameters.trainingGoal == 3)
                {
                    excercise = new Excercise();
                    Excercise excerciseTmp = excercises.FirstOrDefault(x => x.Excercise.PrimaryMuscle == trainingParameters.trainingGoal).Excercise;
                    //dodatkowe
                    excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == trainingParameters.trainingGoal && tmp.FirstOrDefault(y => y.PrimaryMuscle == trainingParameters.trainingGoal).Priority < x.Priority);
                    excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, trainingParameters, 20.0, subtraining1));
                    tmp.Add(excercises.Last().Excercise);
                }

                //Trening B
                Subtraining subtraining2 = new Subtraining();
                subtraining2.Name = "Pull";
                subtraining2.Training = training;
                tmp = new List<Excercise>();
                //nogi
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 3 && x.Priority == 5);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, trainingParameters, 20.0, subtraining2));
                tmp.Add(excercises.Last().Excercise);
                //plecy
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 2 && x.Priority == 41 && trainingParameters.trainingKind == x.Machine);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, trainingParameters, 20.0, subtraining2));
                tmp.Add(excercises.Last().Excercise);
                //biceps
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 4 && x.Priority == 103);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, trainingParameters, 6.0, subtraining2));
                tmp.Add(excercises.Last().Excercise);
                //brzuch
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 6 && x.Priority == 121 && trainingParameters.trainingKind == x.Machine);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, trainingParameters, 20.0, subtraining2));
                tmp.Add(excercises.Last().Excercise);
                if (trainingParameters.trainingGoal == 2)
                {
                    excercise = new Excercise();
                    Excercise excerciseTmp = excercises.FirstOrDefault(x => x.Excercise.PrimaryMuscle == trainingParameters.trainingGoal).Excercise;
                    //dodatkowe
                    excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == trainingParameters.trainingGoal && tmp.FirstOrDefault(y => y.PrimaryMuscle == trainingParameters.trainingGoal).Priority < x.Priority);
                    excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, trainingParameters, 20.0, subtraining1));
                    tmp.Add(excercises.Last().Excercise);
                }

                return excercises;
            }
            else
            {
                if (next != null)
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
