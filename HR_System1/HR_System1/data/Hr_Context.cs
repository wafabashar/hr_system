using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HR_System1.data
{
    public class Hr_Context:IdentityDbContext<ApplicationUser>
    {
        IConfiguration configuration;


        public Hr_Context(IConfiguration _configuration)
        {

            configuration = _configuration;

        }
        public DbSet<Employee> employee { get; set; }

        public DbSet<Department> department { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Hr_System"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
