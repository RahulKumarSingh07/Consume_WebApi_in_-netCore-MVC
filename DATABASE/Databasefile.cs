using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using First.Models;

namespace First.DATABASE
{
    public class Databasefile : DbContext
    {
        public Databasefile(DbContextOptions<Databasefile> options) : base(options) { }
        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        
        public DbSet<EmployeeNew> NewEmployees { get; set; }
        public DbSet<Emptype> Emptypes { get; set; }
        public DbSet<Designation> Designations_Col  { get; set; }

    }
}
