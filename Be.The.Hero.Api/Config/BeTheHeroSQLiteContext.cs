using Be.The.Hero.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace Be.The.Hero.Api.Config
{
    [ExcludeFromCodeCoverage]
    public class BeTheHeroSQLiteContext : DbContext
    {
        public BeTheHeroSQLiteContext(
             DbContextOptions<BeTheHeroSQLiteContext> options) : base(options)
        {
        }

        public DbSet<Ong> Ongs { get; set; }
        public DbSet<Incident> Incidents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Ong>().HasKey(m => m.Id);
            builder.Entity<Incident>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }

    }
}
