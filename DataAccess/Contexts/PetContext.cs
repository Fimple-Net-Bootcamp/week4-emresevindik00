using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class PetContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Pet;Trusted_Connection=true");
            //optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Health> Healths { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Nutrient> Nutrients { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<SocialInteraction> SocialInteractions { get; set; }
    }
}
