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

        List<PersonExcercise> ListPersonExercises(AppUser user);

    }
}
