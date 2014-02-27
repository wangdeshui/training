namespace EF6CodeFirstSamples.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddepartmentstopersons : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.PersonID);
            
            CreateTable(
                "dbo.PersonDepartments",
                c => new
                    {
                        Person_PersonID = c.Int(nullable: false),
                        Department_DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_PersonID, t.Department_DepartmentID })
                .ForeignKey("dbo.People", t => t.Person_PersonID, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentID, cascadeDelete: true)
                .Index(t => t.Person_PersonID)
                .Index(t => t.Department_DepartmentID);
            
            AddColumn("dbo.Departments", "PersonID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonDepartments", "Department_DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.PersonDepartments", "Person_PersonID", "dbo.People");
            DropIndex("dbo.PersonDepartments", new[] { "Department_DepartmentID" });
            DropIndex("dbo.PersonDepartments", new[] { "Person_PersonID" });
            DropColumn("dbo.Departments", "PersonID");
            DropTable("dbo.PersonDepartments");
            DropTable("dbo.People");
        }
    }
}
