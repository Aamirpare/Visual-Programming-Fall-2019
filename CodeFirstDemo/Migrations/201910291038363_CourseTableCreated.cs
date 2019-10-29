namespace CodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseTableCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Code = c.String(),
                        Credits = c.Int(nullable: false),
                        Student_StudentId = c.Int(),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Students", t => t.Student_StudentId)
                .Index(t => t.Student_StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Student_StudentId", "dbo.Students");
            DropIndex("dbo.Courses", new[] { "Student_StudentId" });
            DropTable("dbo.Courses");
        }
    }
}
