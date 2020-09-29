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

        public Training CreateTraining(Training training,int trainingType,int trainingKind)
        {
            _db.Trainings.Add(training);
            
            _db.SaveChanges();
            Training trainingDb= _db.Trainings.OrderBy(x => x.ID).FirstOrDefault();
            CreateSubtraining(trainingDb,trainingType,trainingKind);
            return trainingDb;
        }

        private void CreateSubtraining(Training training,int trainingType,int trainingKind)
        {
            Form form=_db.Forms.FirstOrDefault(x => x.User == training.AppUser);
            FbwTraining fbwTraining= new FbwTraining();
            PushPullTraining pushPullTraining = new PushPullTraining();
            SplitTraining splitTraining = new SplitTraining();
            fbwTraining.SetNext(pushPullTraining);
            pushPullTraining.SetNext(splitTraining);

            TrainingParameters trainingParameters = new TrainingParameters(training, trainingType, form.GoalID, form.TrainingCategoryID, form.FreeTimeID,trainingKind);

            List<TrainingExercise> exercises = fbwTraining.Generate(trainingParameters, _db,training);

            List<Subtraining> subtrainings = GenerateSubtrainings(exercises.Select(x => x.Subtraining).Distinct().ToList());

            GenerateExercisesForSubtrainings(exercises, subtrainings);

            GenerateMaxesForExercises(exercises,training.AppUser);
        }

        public List<Subtraining> GenerateSubtrainings(List<Subtraining> subtrainings)
        {
            List<Subtraining> list = new List<Subtraining>();
            foreach(Subtraining sub in subtrainings)
            {
                _db.Subtrainings.Add(sub);
                _db.SaveChanges();
                list.Add(_db.Subtrainings.FirstOrDefault(x => x.Training == sub.Training && x.Name == sub.Name));
            }
            return list;
        }

        public void GenerateExercisesForSubtrainings(List<TrainingExercise> exercises, List<Subtraining> subtrainings)
        {
            foreach(TrainingExercise exercise in exercises)
            {
                exercise.Subtraining = subtrainings.FirstOrDefault(x => x.Name == exercise.Subtraining.Name);
                _db.TrainingExercises.Add(exercise);
            }
            _db.SaveChanges();
        }

        public void GenerateMaxesForExercises(List<TrainingExercise> excercises,AppUser user)
        {
            foreach(TrainingExercise trainingExcercise in excercises)
            {
                PersonExcercise personExcercise = new PersonExcercise();
                personExcercise.Excercise = trainingExcercise.Excercise;
                personExcercise.Max = trainingExcercise.Weight;
                personExcercise.Progress = 5.0;
                personExcercise.AppUser = user;
                _db.PeopleExercises.Add(personExcercise);
            }
            _db.SaveChanges();
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
