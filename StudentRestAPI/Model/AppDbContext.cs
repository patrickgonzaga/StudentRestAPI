using Microsoft.EntityFrameworkCore;

namespace StudentRestAPI.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // send Student Table
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = Guid.NewGuid(),
                    FirstName = "Patrick James",
                    LastName = "Gonzaga",
                    Email = "patrick.gonzaga@yahoo.com",
                    DateOfBirth = new DateTime(2000,1,1),
                    Gender = Gender.Male,
                    DepartmentId = 1,
                    PhotoPath = "Images/PatrickGonzaga.png"
                });

            modelBuilder.Entity<Student>().HasData(
               new Student
               {
                   StudentId = Guid.NewGuid(),
                   FirstName = "Robert James",
                   LastName = "Gonzaga",
                   Email = "robert.gonzaga@yahoo.com",
                   DateOfBirth = new DateTime(1982, 5, 10),
                   Gender = Gender.Male,
                   DepartmentId = 1,
                   PhotoPath = "Images/RobertGonzaga.png"
               });
            modelBuilder.Entity<Student>().HasData(
               new Student
               {
                   StudentId = Guid.NewGuid(),
                   FirstName = "Michael James",
                   LastName = "Gonzaga",
                   Email = "michael.gonzaga@yahoo.com",
                   DateOfBirth = new DateTime(2005, 12, 1),
                   Gender = Gender.Male,
                   DepartmentId = 1,
                   PhotoPath = "Images/MichaelGonzaga.png"
               });
            modelBuilder.Entity<Student>().HasData(
              new Student
              {
                  StudentId = Guid.NewGuid(),
                  FirstName = "Christine Joannn",
                  LastName = "Gonzaga",
                  Email = "christine.gonzaga@yahoo.com",
                  DateOfBirth = new DateTime(2010, 4, 15),
                  Gender = Gender.Female,
                  DepartmentId = 1,
                  PhotoPath = "Images/ChristineGonzaga.png"
              });
            modelBuilder.Entity<Student>().HasData(
              new Student
              {
                  StudentId = Guid.NewGuid(),
                  FirstName = "Barbra Joann",
                  LastName = "Gonzaga",
                  Email = "barbra.gonzaga@yahoo.com",
                  DateOfBirth = new DateTime(2015, 8, 11),
                  Gender = Gender.Female,
                  DepartmentId = 1,
                  PhotoPath = "Images/BarbraGonzaga.png"
              });
        }

    }
}
