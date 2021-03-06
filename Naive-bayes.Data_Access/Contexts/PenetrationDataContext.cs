﻿using Naive_bayes.Data_Access.Configurations;
using Naive_bayes.Data_Access.Models;
using SQLite.CodeFirst;
using System.Data.Entity;

namespace Naive_bayes.Data_Access.Contexts
{
    public class PenetrationDataContext : DbContext
    {
        public DbSet<Angle> Angles { get; set; }
        public DbSet<Armor> Armors { get; set; }
        public DbSet<Penetration> Penetrations { get; set; }
        public DbSet<PenetrationDataPoint> PenetrationDataPoints { get; set; }
        public DbSet<ShellSize> ShellSizes { get; set; }
        public DbSet<ShellType> ShellTypes { get; set; }

        public PenetrationDataContext() : base("PenDB")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<PenetrationDataContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new PenetrationDataPointConfiguration());
        }
    }
}
