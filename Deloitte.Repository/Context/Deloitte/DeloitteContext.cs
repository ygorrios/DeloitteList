using Deloitte.Repository.Context.Deloitte.Models;
using Microsoft.EntityFrameworkCore;

namespace Deloitte.Repository.Context.Deloitte
{
    public class DeloitteContext : DbContext
    {
        public DeloitteContext(DbContextOptions<DeloitteContext> options)
        : base(options)
        {
        }


        public DbSet<User> User { get; set; }
        public DbSet<TaskDetail> TaskDetail { get; set; }
        public DbSet<TaskHistory> TaskHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
            }
        }
    }
}
