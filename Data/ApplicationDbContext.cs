using car_web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace car_web.Data
{
	public class ApplicationDbContext :  IdentityDbContext<AppUser>
	{

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
             
        }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Car> Cars { get; set; }
		public DbSet<Combany> Combanies { get; set; }

        protected override void OnModelCreating(  ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Combany>().HasData(
                new Combany { Id = 1, Name = "HONDA" },
                new Combany { Id = 2, Name = "HYUNDAI" });
        }

    }
}
