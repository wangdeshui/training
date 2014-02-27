using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 http://www.entityframeworktutorial.net/code-first/entity-framework-code-first.aspx
 from Tools → Library Package Manager → Package Manager Console
 PM: Enable-Migrations
 PM: add-migration "first db schema"
 PM: update-database   it will make database to latest version
 PM: update-database  -TargetMigration "InitialCreate"   it will roll back to initial version 
 */


namespace EF6CodeFirstSamples
{
    public class BlogsEntities : DbContext
    {
        public BlogsEntities()
        {
            //Database.SetInitializer(new BlogDBInitializer());
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<Person> Persons { get; set; }

    }

    public class Person
    {
        public int PersonID { get; set; }
        public virtual ICollection<Department> Departments { get; set; } 
    }


    public class Department
    {
        // Primary key
        [Key]
        public int DepartmentID { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }


        public int PersonID { get; set; }

        public virtual ICollection<Person> Persons { get; set; }

        // Navigationproperty
        public virtual ICollection<Course> Courses { get; set; }
    }

    public class Course
    {
        // Primary key
        public int CourseID { get; set; }

        public string Title { get; set; }
        public int Credits { get; set; }

        // Foreign key
        
        public int DepartmentID { get; set; }

        // Navigationproperties
        public virtual Department Department { get; set; }
    }


    public class OnsiteCourse : Course
    {
        public OnsiteCourse()
        {
            Details = new Details();
        }

        public Details Details { get; set; }
    }

    // this will be complex type as have not primary key, the fields will added to Course table
    public class Details
    {
        public System.DateTime Time { get; set; }
        public string Location { get; set; }
        public string Days { get; set; }
    }


    public class BlogDBInitializer : DropCreateDatabaseAlways<BlogsEntities>
    {
        protected override void Seed(BlogsEntities context)
        {
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

            context.Departments.Add(tDepartment);
            base.Seed(context);
        }
    }

}
