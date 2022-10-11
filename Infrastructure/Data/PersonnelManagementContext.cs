using Microsoft.EntityFrameworkCore;
using Model;

namespace Infrastructure.Data
{
    public class PersonnelManagementContext : DbContext
    {
        public DbSet<Department>? Department { get; set; }
        public DbSet<Employee>? Employee { get; set; }
        public DbSet<PersonnelMovements>? PersonnelMovements { get; set; }

        public PersonnelManagementContext(DbContextOptions<PersonnelManagementContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            Department HR = new() { Id = 1, Name = "Department of Human Resources Management" };
            Department Finance = new() { Id = 4, Name = "Department of Finance" };

            modelBuilder.Entity<Department>().HasData(
                HR,
                new Department { Id = 2, Name = "Talent Planning, Acquisition and Development Division", GroupDepartmentId = 1 },
                new Department { Id = 3, Name = "Employee Service, Reletions and Policies Division", GroupDepartmentId = 1 },
                Finance,
                new Department { Id = 5, Name = "Budget Services Division", GroupDepartmentId = 4 },
                new Department { Id = 6, Name = "Accounts, Payments and Treasury Division", GroupDepartmentId = 4 },
                new Department { Id = 7, Name = "Financial Management of Technical Cooperation Division", GroupDepartmentId = 4 }
                );

            Random random = new();
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = 1, FirstName = "Brown", LastName = "Yundt", DateOfBirth = DateTime.Now.AddDays(random.Next(365 * 20, 365 * 60) * -1) },
                new Employee() { Id = 2, FirstName = "Alvina", LastName = "Schuppe", DateOfBirth = DateTime.Now.AddDays(random.Next(365 * 20, 365 * 60) * -1) },
                new Employee() { Id = 3, FirstName = "Jaeden", LastName = "Okuneva", DateOfBirth = DateTime.Now.AddDays(random.Next(365 * 20, 365 * 60) * -1) },
                new Employee() { Id = 4, FirstName = "Deangelo", LastName = "Bauch", DateOfBirth = DateTime.Now.AddDays(random.Next(365 * 20, 365 * 60) * -1) },
                new Employee() { Id = 5, FirstName = "Davonte", LastName = "White", DateOfBirth = DateTime.Now.AddDays(random.Next(365 * 20, 365 * 60) * -1) },
                new Employee() { Id = 6, FirstName = "Joy", LastName = "Buckridge", DateOfBirth = DateTime.Now.AddDays(random.Next(365 * 20, 365 * 60) * -1) },
                new Employee() { Id = 7, FirstName = "Madyson", LastName = "D'Amore", DateOfBirth = DateTime.Now.AddDays(random.Next(365 * 20, 365 * 60) * -1) },
                new Employee() { Id = 8, FirstName = "Ibrahim", LastName = "Rosenbaum", DateOfBirth = DateTime.Now.AddDays(random.Next(365 * 20, 365 * 60) * -1) },
                new Employee() { Id = 9, FirstName = "Dessie", LastName = "McGlynn", DateOfBirth = DateTime.Now.AddDays(random.Next(365 * 20, 365 * 60) * -1) },
                new Employee() { Id = 10, FirstName = "Laisha", LastName = "Glover", DateOfBirth = DateTime.Now.AddDays(random.Next(365 * 20, 365 * 60) * -1) }
                );
        }
    }
}
