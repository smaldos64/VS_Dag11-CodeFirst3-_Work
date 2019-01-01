namespace Dag11_CodeFirst3__Work.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentCourseCollections",
                c => new
                    {
                        StudentCourseCollectionID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                        TeamID = c.Int(nullable: false),
                        CourseComment = c.String(),
                        CharacterValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentCourseCollectionID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.TeamID, cascadeDelete: false)
                .Index(t => t.StudentID)
                .Index(t => t.CourseID)
                .Index(t => t.TeamID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                    })
                .PrimaryKey(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourseCollections", "TeamID", "dbo.Teams");
            DropForeignKey("dbo.StudentCourseCollections", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentCourseCollections", "CourseID", "dbo.Courses");
            DropIndex("dbo.StudentCourseCollections", new[] { "TeamID" });
            DropIndex("dbo.StudentCourseCollections", new[] { "CourseID" });
            DropIndex("dbo.StudentCourseCollections", new[] { "StudentID" });
            DropTable("dbo.Courses");
            DropTable("dbo.StudentCourseCollections");
        }
    }
}
