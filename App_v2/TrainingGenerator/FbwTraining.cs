using App_v2.Models;
using App_v2.Tools;
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

                //Trening A
                Subtraining subtraining1 = new Subtraining();
                subtraining1.Name = "A";
                subtraining1.Training = training;
                //klata
                Excercise excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 1 && x.Priority==21);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, 5, 5, 20.0, subtraining1));
                tmp.Add(excercises.Last().Excercise);
                //nogi
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 3 && x.Priority == 1);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, 5, 5, 20.0, subtraining1));
                tmp.Add(excercises.Last().Excercise);
                //plecy
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 2 && x.Priority == 46 &&x.Machine==trainingParameters.trainingKind);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, 5, 5, 20.0, subtraining1));
                tmp.Add(excercises.Last().Excercise);
                //Barki
                excercise = new Excercise();
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 7 && x.Priority == 62);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise,8, 3, 4.0, subtraining1));
                tmp.Add(excercises.Last().Excercise);
                //Triceps
                excercise = new Excercise();
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 5 && x.Priority == 83);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, 8, 3, 0.0, subtraining1));
                tmp.Add(excercises.Last().Excercise);
                //biceps
                excercise = new Excercise();
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 4 && x.Priority == 103);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, 8, 3, 8.0, subtraining1));
                tmp.Add(excercises.Last().Excercise);
                //brzuch
                excercise = new Excercise();
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 6 && x.Priority == 121 && trainingParameters.trainingKind==x.Machine);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, 8, 3, 20.0, subtraining1));
                tmp.Add(excercises.Last().Excercise);
                //dodatkowe
                excercise = new Excercise();
                Excercise excerciseTmp = excercises.FirstOrDefault(x => x.Excercise.PrimaryMuscle == trainingParameters.trainingGoal).Excercise;
                if(excerciseTmp.Machine==true)
                {
                    excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == trainingParameters.trainingGoal && tmp.FirstOrDefault(y => y.PrimaryMuscle == trainingParameters.trainingGoal).Priority < x.Priority && x.Machine != trainingParameters.trainingKind);
                }
                else
                {
                    excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == trainingParameters.trainingGoal && tmp.FirstOrDefault(y => y.PrimaryMuscle == trainingParameters.trainingGoal).Priority < x.Priority && x.Machine != trainingParameters.trainingKind);
                }
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, 8, 3, 10.0, subtraining1));
                tmp.Add(excercises.Last().Excercise);





                //Trening B
                Subtraining subtraining2 = new Subtraining();
                subtraining2.Name = "B";
                subtraining2.Training = training;
                //klata
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 1 && x.Priority == 28);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, 5, 5, 8.0, subtraining2));
                //nogi
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 3 && x.Priority == 5);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, 5, 5, 20.0, subtraining2));
                //plecy
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 2 && x.Priority == 41 && x.Machine == trainingParameters.trainingKind);
                if(trainingParameters.trainingKind==true)
                {
                    excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, 5, 5, 10.0, subtraining2));  
                }
                else
                {
                    excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, 5, 5, 0.0, subtraining2));
                }
                //Barki
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 7 && x.Priority == 61);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, 5, 5, 10.0, subtraining2));
                //Triceps
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 5 && x.Priority == 81);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, 8, 3, 10.0, subtraining2));
                //biceps
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 4 && x.Priority == 104);
                excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, 8, 3, 8.0, subtraining2));
                //brzuch
                excercise = dbContext.Excercises.FirstOrDefault(x => x.PrimaryMuscle == 6 && x.Priority == 122 && x.Machine==trainingParameters.trainingKind);
                if(excercise.Machine==true)
                {
                    excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, 8, 3, 10.0, subtraining2));
                }
                else
                {
                    excercises.Add(GlobalFunctions.SetTrainingExercise(excercise, 8, 3, 20.0, subtraining2));
                }



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
