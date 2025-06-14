using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("persons");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id").UseIdentityAlwaysColumn();
                entity.Property(e => e.Nom).HasColumnName("nom").HasColumnType("character(50)");
                entity.Property(e => e.Prenom).HasColumnName("prenom").HasColumnType("character(50)");
                entity.Property(e => e.Age).HasColumnName("age").HasColumnType("integer");
                entity.Property(e => e.Adresse).HasColumnName("adresse").HasColumnType("character(50)");
            });
        }
    }
}