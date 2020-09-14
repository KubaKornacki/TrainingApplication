using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App_v2.Models;

namespace App_v2.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly AppDbContext _db;

        public TrainingRepository(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        public void CloseTraining(int trainingId)
        {
            throw new NotImplementedException();
        }

        public int CreateTraining(Training training)
        {
            _db.Trainings.Add(training);
            _db.SaveChanges();
            return _db.Trainings.OrderBy(x => x.ID).FirstOrDefault().ID;
        }

        public Training GetTraining(Training training)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Training> ListAllTraining(AppUser appUser)
        {
            throw new NotImplementedException();
        }

        public void UpdateTraining(Training training)
        {
            throw new NotImplementedException();
        }
    }
}
