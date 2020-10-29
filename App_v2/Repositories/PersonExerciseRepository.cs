using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App_v2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace App_v2.Repositories
{
    public class PersonExerciseRepository : IPersonExerciseRepository
    {
        private readonly AppDbContext _db;
        public PersonExerciseRepository(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        public void AddPersonExercise(PersonExcercise personExercise)
        {
            _db.PeopleExercises.Add(personExercise);
            _db.SaveChanges();
        }

        public PersonExcercise GetPersonExcercise(int id)
        {
            return _db.PeopleExercises.FirstOrDefault(x => x.ID == id);
        }

        public List<PersonExcercise> ListPersonExercises(AppUser user)
        {
            return _db.PeopleExercises.Include(p => p.Excercise).Where(x => x.AppUser == user).ToList();
        }

        public List<PersonExcercise> ListPersonExercises(string userId)
        {
            return _db.PeopleExercises.Include(p => p.Excercise).Where(x => x.AppUser.Id == userId).ToList();
        }

        public void UpdatePersonExercise(PersonExcercise personExcercise)
        {

            if(personExcercise.Excercise==null||personExcercise.AppUser==null)
            {
                PersonExcercise excercise = GetPersonExcercise(personExcercise.ID);
                excercise.Max = personExcercise.Max;
                excercise.Progress = personExcercise.Progress;
                _db.PeopleExercises.Update(excercise);
            }
            else
            {
                _db.PeopleExercises.Update(personExcercise);
            }
            _db.SaveChanges();
        }

        public void UpdatePersonExercise(int idExercise, double weight,int reps,string userId)
        {
           PersonExcercise pe= _db.PeopleExercises.FirstOrDefault(x => x.Excercise.ID == idExercise && x.AppUser.Id == userId);
            if(weight<(pe.Max*0.8))
            {
                if(pe.Progress-1>=0)
                pe.Progress--;
            }
            else
            {
                pe.Max = Math.Round(((weight * reps) * 0.0333) + weight,2);
            }
            pe.LastTrainingMax = weight;
            _db.PeopleExercises.Update(pe);
            _db.SaveChanges();
        }
    }
}
