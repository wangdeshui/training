namespace EF6CodeFirstSamples.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EF6CodeFirstSamples.BlogsEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EF6CodeFirstSamples.BlogsEntities";
        }

        protected override void Seed(EF6CodeFirstSamples.BlogsEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            Department tDepartment = new Department
            {
                Name = "IT",
                Courses = new Course[]
                {
                    new Course {Credits = 10, Title = "CourseA"},
                    new OnsiteCourse
                    {
                        Title = "Onsite CourseA",
                        Details = new Details {Time = DateTime.Now, Days = "Love", Location = "Xian"}
                    }
                }
            };

            context.Departments.AddOrUpdate(tDepartment);
            base.Seed(context);
        }
    }
}
