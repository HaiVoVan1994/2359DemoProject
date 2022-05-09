using InterviewProject.Common.Services;
using InterviewProject.Domains;
using InterviewProject.Domains.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace InterviewProject.Infrastructure
{
    public class DataContext : DbContext
    {
        private readonly IUserService _userService;
        public DataContext(DbContextOptions<DataContext> options, IUserService userService)
            : base(options)
        {
            _userService = userService;
        }

        protected DataContext(DbContextOptions options)
            : base(options)
        {

        }

        public DataContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // To modify later
            optionsBuilder.UseSqlServer("Server=localhost;Database=InterviewProject;Trusted_Connection=true;Integrated Security=True;MultipleActiveResultSets=True;App=InterviewProject");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(b => b.DOB)
                .IsRequired(false);

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UnitOfMeasureConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration(_userService));
        }

        public virtual DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
