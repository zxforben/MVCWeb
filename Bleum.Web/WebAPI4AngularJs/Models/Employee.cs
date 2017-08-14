using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPI4AngularJs.Models
{
    public class Employee
    {
        public int EmployeeId
        {
            get;
            set;
        }
        [Required]
        [StringLength(20)]
        public string FirstName
        {
            get;
            set;
        }
        [Required]
        [StringLength(20)]
        public string LastName
        {
            get;
            set;
        }
        [Required]
        [StringLength(100)]
        public string Description
        {
            get;
            set;
        }
        public float Salary
        {
            get;
            set;
        }
        [Required]
        [StringLength(50)]
        public string Country
        {
            get;
            set;
        }
        [Required]
        [StringLength(50)]
        public string State
        {
            get;
            set;
        }
        public DateTime DateofBirth
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
    }

    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext() : base()
        {
            Database.SetInitializer<EmployeeDbContext>(new EmployeeDbContextInitializer());
        }
        public DbSet<Employee> Employees
        {
            get;
            set;
        }
    }
    public class EmployeeDbContextInitializer : DropCreateDatabaseIfModelChanges<EmployeeDbContext>
    {
        protected override void Seed(EmployeeDbContext context)
        {
            var list = new List<Employee>
        {
            new Employee
            {
                FirstName = "Rohit", LastName = "Mane", Description = "Rohit Mane", DateofBirth = DateTime.Now.AddYears(-24), Country = "IN", State = "MH", Salary = 99999, IsActive = true
            },
            new Employee
            {
                FirstName = "Shankar", LastName = "Kanase", Description = "Rahul Singh", DateofBirth = DateTime.Now.AddYears(-23), Country = "IN", State = "MH", Salary = 49999.28f, IsActive = true
            }
        };
            list.ForEach(m =>
            {
                context.Employees.Add(m);
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}