using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App_v2.Models;
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
    }
}
