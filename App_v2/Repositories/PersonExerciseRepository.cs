using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App_v2.Models;

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
        }

        public IEnumerable<PersonExcercise> GetPersonExercises(AppUser user)
        {
            return _db.PeopleExercises.Where(x => x.AppUser == user);
        }

        public void UpdatePersonExercise(PersonExcercise personExcercise)
        {
            _db.PeopleExercises.Update(personExcercise);
        }
    }
}
