namespace CodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseTableChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Student_StudentId", "dbo.Students");
            DropIndex("dbo.Courses", new[] { "Student_StudentId" });
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Student_StudentId = c.Int(nullable: false),
                        Course_CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentId, t.Course_CourseID })
                .ForeignKey("dbo.Students", t => t.Student_StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_CourseID, cascadeDelete: true)
                .Index(t => t.Student_StudentId)
                .Index(t => t.Course_CourseID);
            
            DropColumn("dbo.Courses", "Student_StudentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Student_StudentId", c => c.Int());
            DropForeignKey("dbo.StudentCourses", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.StudentCourses", "Student_StudentId", "dbo.Students");
            DropIndex("dbo.StudentCourses", new[] { "Course_CourseID" });
            DropIndex("dbo.StudentCourses", new[] { "Student_StudentId" });
            DropTable("dbo.StudentCourses");
            CreateIndex("dbo.Courses", "Student_StudentId");
            AddForeignKey("dbo.Courses", "Student_StudentId", "dbo.Students", "StudentId");
        }
    }
}
