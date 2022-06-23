using Microsoft.EntityFrameworkCore;
using Solor_BackEnd.Models;

namespace Solor_BackEnd.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
       public DbSet<Slider> Sliders { get; set; }
       public DbSet<About> Abouts { get; set; }
       public DbSet<Service> Services { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
