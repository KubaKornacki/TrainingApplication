using App_v2.Models;
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
    }
}
