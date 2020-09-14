using App_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.Repositories
{
    interface IPersonExerciseRepository
    {
        IEnumerable<PersonExcercise> GetPersonExercises(AppUser user);

        void AddPersonExercise(PersonExcercise personExercise);

        void UpdatePersonExercise(PersonExcercise personExcercise);

    }
}
