using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App_v2.Models;
using App_v2.TrainingGenerator;

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

        public Training CreateTraining(Training training,int trainingType)
        {
            _db.Trainings.Add(training);
            
            _db.SaveChanges();
            Training trainingDb= _db.Trainings.OrderBy(x => x.ID).FirstOrDefault();
            CreateTrainingExcercises(trainingDb,trainingType);
            return trainingDb;
        }

        private void CreateTrainingExcercises(Training training,int trainingType)
        {
            Form form=_db.Forms.FirstOrDefault(x => x.User == training.AppUser);
            FbwTraining fbwTraining= new FbwTraining();
            PushPullTraining pushPullTraining = new PushPullTraining();
            SplitTraining splitTraining = new SplitTraining();
            fbwTraining.SetNext(pushPullTraining);
            pushPullTraining.SetNext(splitTraining);

            TrainingParameters trainingParameters = new TrainingParameters(training, trainingType, form.GoalID, form.TrainingCategoryID, form.FreeTimeID);

            IEnumerable<TrainingExercise> exercises = fbwTraining.Generate(trainingParameters);


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
