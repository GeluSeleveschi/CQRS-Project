using CQRS_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Project.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("sqlConnection"));
        }

        public DbSet<StudentDetails> Students { get; set; }
    }
}
