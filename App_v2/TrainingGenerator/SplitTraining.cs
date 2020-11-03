using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App_v2.Models;
using App_v2.Tools;

namespace App_v2.TrainingGenerator
{
    public class SplitTraining : Chain
    {
        public override List<TrainingExercise> Generate(TrainingParameters trainingParameters, AppDbContext dbContext,Training training)
        {
            if (trainingParameters.trainingType == 3)
            {
                List<TrainingExercise> excercises = new List<TrainingExercise>();

                //Trening A
                Subtraining subtraining1 = new Subtraining();
                subtraining1.Name = "Plecy +Biceps";
                subtraining1.Training = training;
                //plecy
                Excercise excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 2 && x.Priority == 41);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, trainingParameters, 20.0, subtraining1));

                //plecy
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 2 && x.Priority == 47 && x.Machine == trainingParameters.trainingKind);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, trainingParameters, 20.0, subtraining1));

                //biceps
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 4 && x.Priority == 101);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, trainingParameters, 20.0, subtraining1));

                //biceps
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 4 && x.Priority == 102);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, trainingParameters, 20.0, subtraining1));

                if(trainingParameters.trainingGoal==3)
                {
                    excercise = new Excercise();
                    Excercise excerciseTmp = excercises.FirstOrDefault(x => x.Excercise.PrimaryMuscle == trainingParameters.trainingGoal).Excercise;
                    //dodatkowe
                    excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 2 && x.Priority==46 && x.Machine == trainingParameters.trainingKind);
                    excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, trainingParameters, 20.0, subtraining1));

                }

                //Trening B
                Subtraining subtraining2 = new Subtraining();
                subtraining2.Name = "Klata + Triceps";
                subtraining2.Training = training;

                //klata
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 1 && x.Priority == 21);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, trainingParameters, 20.0, subtraining2));

                //klata
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 1 && x.Priority == 25 && x.Machine == trainingParameters.trainingKind);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, trainingParameters, 20.0, subtraining2));

                //triceps
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 5 && x.Priority == 81);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, trainingParameters, 20.0, subtraining2));

                //triceps
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 5 && x.Priority == 86);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, trainingParameters, 20.0, subtraining2));

                if (trainingParameters.trainingGoal == 1)
                {
                    excercise = new Excercise();
                    Excercise excerciseTmp = excercises.FirstOrDefault(x => x.Excercise.PrimaryMuscle == trainingParameters.trainingGoal).Excercise;
                    //dodatkowe
                    excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 1 && x.Priority == 23 && x.Machine == trainingParameters.trainingKind);
                    excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, trainingParameters, 20.0, subtraining2));

                }

                //Trening C
                Subtraining subtraining3 = new Subtraining();
                subtraining3.Name = "Nogi + brzuch";
                subtraining3.Training = training;

                //nogi
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 3 && x.Priority == 1 && x.Machine == trainingParameters.trainingKind);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, trainingParameters, 20.0, subtraining3));

                //nogi
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 3 && x.Priority == 4);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, trainingParameters, 20.0, subtraining3));

                //brzuch
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 6 && x.Priority == 121 && x.Machine == trainingParameters.trainingKind);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, trainingParameters, 20.0, subtraining3));

                //brzuch
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 6 && x.Priority == 122 && x.Machine == trainingParameters.trainingKind);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, trainingParameters, 20.0, subtraining3));

                if (trainingParameters.trainingGoal == 3)
                {
                    excercise = new Excercise();
                    Excercise excerciseTmp = excercises.FirstOrDefault(x => x.Excercise.PrimaryMuscle == trainingParameters.trainingGoal).Excercise;
                    //dodatkowe
                    excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 3 && x.Priority == 3);
                    excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, trainingParameters, 10.0, subtraining3));

                }




                return excercises;
            }
            else
            {
                if (next != null)
                {
                    return next.Generate(trainingParameters, dbContext,training);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
