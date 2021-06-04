using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Toy.Core.Entities.Concrete;
using Toy.Entities.Concrete;

namespace Toy.DataAccess.Concrete.EntityFramework
{
   public class OyuncakSatisContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\mssqllocaldb;database=OyuncakSatis;Trusted_Connection=True");
        }

        public DbSet<PlushToy> PlushToys { get; set; }
        public DbSet<EducationalToy> EducationalToys { get; set; }
        public DbSet<PuzzleToy> PuzzleToys { get; set; }
        public DbSet<ScienceToy> ScienceToys{ get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }

    }
}
