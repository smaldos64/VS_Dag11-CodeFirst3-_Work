namespace Dag11_CodeFirst3__Work.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CodeModelDB : DbContext
    {
        // Your context has been configured to use a 'CodeModelDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Dag11_CodeFirst3__Work.Models.CodeModelDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CodeModelDB' 
        // connection string in the application configuration file.
        public CodeModelDB()
            : base("name=CodeModelDB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CharacterWork> CharacterWorks { get; set; }
        public virtual DbSet<StudentCourseCollection> StudentCourseCollections { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}