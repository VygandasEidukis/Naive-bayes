namespace Naive_bayes.Data_Access.Migrations
{
    using Naive_bayes.Data_Access.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Naive_bayes.Data_Access.Contexts.PenetrationDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Naive_bayes.Data_Access.Contexts.PenetrationDataContext context)
        {
            context.Angles.AddOrUpdate
                (
                    new Angle() { Id = 1, angle = "Flat" },
                    new Angle() { Id = 2, angle = "Small" },
                    new Angle() { Id = 3, angle = "Medium" },
                    new Angle() { Id = 4, angle = "Big" },
                    new Angle() { Id = 5, angle = "Effective" }
                );
            context.SaveChanges();

            context.Armors.AddOrUpdate
                (
                    new Armor() { Id = 1, armor = "Thin" },
                    new Armor() { Id = 2, armor = "Medium" },
                    new Armor() { Id = 3, armor = "Thick" }
                );
            context.SaveChanges();

            context.Penetrations.AddOrUpdate
                (
                    new Penetration() { Id = 1, penetration = "low" },
                    new Penetration() { Id = 2, penetration = "Medium" },
                    new Penetration() { Id = 3, penetration = "High" }
                );
            context.SaveChanges();

            context.ShellSizes.AddOrUpdate
                (
                    new ShellSize() { Id = 1, Size = "Small" },
                    new ShellSize() { Id = 2, Size = "Medium" },
                    new ShellSize() { Id = 3, Size = "Big" }
                );
            context.SaveChanges();

            context.ShellTypes.AddOrUpdate
                (
                    new ShellType() { Id = 1, Type = "AP" },
                    new ShellType() { Id = 2, Type = "APCR" },
                    new ShellType() { Id = 3, Type = "HE" }
                );
            context.SaveChanges();
        }
    }
}
