using App_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.Repositories
{
    public interface IPersonExerciseRepository
    {
        void AddPersonExercise(PersonExcercise personExercise);

        void UpdatePersonExercise(PersonExcercise personExcercise);

        PersonExcercise GetPersonExcercise(int id);

        List<PersonExcercise> ListPersonExercises(string userId);

        List<PersonExcercise> ListPersonExercises(AppUser user);

        void UpdatePersonExercise(int idExercise,double weight,int reps,string userId);
    }
}
