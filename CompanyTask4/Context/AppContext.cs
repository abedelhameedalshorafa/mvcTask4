using CompanyTask4.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyTask4.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> option):base(option)
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<Department> departments { get; set; }

        public DbSet<taskItems> tasks { get; set; }

        public DbSet<Feedback> feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

    }
}
