using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.Models
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Dict> Dicts { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Excercise> Excercises { get; set; }
        public DbSet<PersonExcercise> PeopleExercises { get; set; }
        public DbSet<Training> Trainings { get; set; }
    }
}
