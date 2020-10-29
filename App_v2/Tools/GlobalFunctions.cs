using App_v2.Models;
using App_v2.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.Tools
{
    public static class GlobalFunctions
    {
        public static List<SelectListItem> GenerateDropdownListForDict(int? selected,IEnumerable<Dict> list)
        {
            List<SelectListItem> listItem = new List<SelectListItem>();
            foreach (var item in list)
            {
                if (item.intValue != selected)
                {
                    listItem.Add(new SelectListItem { Text = item.textValue, Value = item.intValue.ToString() });
                }
                else
                {
                    listItem.Add(new SelectListItem { Text = item.textValue, Value = item.intValue.ToString(), Selected = true });
                }
            }

            return listItem;
        }

        public static TrainingExercise SetTrainingExercise(Excercise excercise, int reps, int sets, double weight, Subtraining subtraining)
        {
            TrainingExercise trainingExercise = new TrainingExercise();
            trainingExercise.Excercise = excercise;
            trainingExercise.DateTime = DateTime.Now;
            trainingExercise.Repeat = reps;
            trainingExercise.Set = sets;
            trainingExercise.Weight = weight;
            trainingExercise.Subtraining = subtraining;
            return trainingExercise;
        }

        public static List<AddHistoryTrainingViewModel> GenerateHistoryTrainings(List<TrainingExercise> trainingExercises,List<PersonExcercise> personExcercises)
        {
            List<AddHistoryTrainingViewModel> viewModels = new List<AddHistoryTrainingViewModel>();
            foreach(TrainingExercise tex in trainingExercises)
            {
                AddHistoryTrainingViewModel model = new AddHistoryTrainingViewModel();
                double weight = personExcercises.FirstOrDefault(x => x.Excercise.ID == tex.Excercise.ID).Max*0.8;
                double progress = personExcercises.FirstOrDefault(x => x.Excercise.ID == tex.Excercise.ID).Progress;
                //model.HistoryTrainings = new List<HistoryTraining>();
                model.TrainingExercise = tex;
                List<HistoryTraining> historyTrainings = new List<HistoryTraining>();
                for (int i=0;i<tex.Set;i++)
                {
                    HistoryTraining ht = new HistoryTraining();
                    ht.TrainingExercise = tex;
                    ht.SetN = i + 1;
                    ht.Repeats = tex.Repeat;
                    if(weight>0)
                    {
                        ht.Weight = Math.Round(weight+progress,2);
                    }
                    else
                    {
                        ht.Weight = tex.Weight;
                    }
                    historyTrainings.Add(ht);
                }
                model.HistoryTrainings = historyTrainings;
                viewModels.Add(model);
            }
            return viewModels;
        }
    }
}
