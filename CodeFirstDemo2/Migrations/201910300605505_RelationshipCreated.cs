namespace CodeFirstDemo2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationshipCreated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Student_StudentId", c => c.Int());
            CreateIndex("dbo.Courses", "Student_StudentId");
            AddForeignKey("dbo.Courses", "Student_StudentId", "dbo.Students", "StudentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Student_StudentId", "dbo.Students");
            DropIndex("dbo.Courses", new[] { "Student_StudentId" });
            DropColumn("dbo.Courses", "Student_StudentId");
        }
    }
}
