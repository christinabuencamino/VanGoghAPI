using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using VanGoghAPI.Models;

namespace VanGoghAPI.Models
{
    public class VanGoghDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public VanGoghDBContext(DbContextOptions<VanGoghDBContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("VanGoghService");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Painting> Painting { get; set; } = null!;
        public DbSet<PaintingInfo> PaintingInfo { get; set; } = null!;

    }
}
