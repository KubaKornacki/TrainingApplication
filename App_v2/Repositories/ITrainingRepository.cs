using App_v2.Models;
using App_v2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.Repositories
{
    public interface ITrainingRepository
    {

        Training CreateTraining(Training training,int trainingType,int trainingKind);

        void UpdateTraining(Training training);

        void CloseTraining(int trainingId);

        Training GetTraining(Training training);

        IEnumerable<Training> ListAllTraining(AppUser appUser);

        IEnumerable<Subtraining> ListSubtrainings(int trainingId);

        IEnumerable<TrainingExercise> GetSubtraingsExercises(int subtrainingId);

        TrainingExercise GetTrainingExercise(int id);

        IEnumerable<HistoryTraining> ListHistoryTrainings(int subtrainingId,DateTime date);

        IEnumerable<DateTime> ListHistoryTrainingsDates(int subtrainingId);

        HistoryTraining GetHistoryTraining(int trainingExcerciseId,int setN, DateTime createDatetime);

        bool AddHistoryTrainings(List<SaveHistoryTrainingViewModel> vm);

        bool FirstTraining(int subtrainingId);

    }
}
