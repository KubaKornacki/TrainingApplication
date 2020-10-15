using App_v2.Models;
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


    }
}
