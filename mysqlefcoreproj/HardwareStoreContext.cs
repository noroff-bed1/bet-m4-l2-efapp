using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using System.Linq;

namespace mysqlefcore
{
  //Inherits from the DbContext
  public class HardwareStoreContext : DbContext
  {
    public DbSet<Tool> Tool { get; set; }

    public DbSet<Brand> Brand { get; set; }
    public DbSet<Category> Category { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      //REPLACE WITH YOUR OWN DB USER CREDENTIALS
      //DB Connection configuration
      optionsBuilder.UseMySQL("server=localhost;database=hardwarestore;user=root;password=p@ssw0rd");
    }

    //Builds database tables with specified columns and relationships
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Brand>(entity =>
      {
        entity.HasKey(e => e.ID);
        entity.Property(e => e.Name).IsRequired();
      });

      modelBuilder.Entity<Tool>(entity =>
      {
        entity.HasKey(e => e.ID);
        entity.Property(e => e.Name).IsRequired();
        entity.Property(e => e.Price).IsRequired();
        entity.HasOne(d => d.Brand)
          .WithMany(p => p.Tools);
        entity.HasOne(f => f.Category)
          .WithMany(p => p.Tools);
      });

      modelBuilder.Entity<Category>(entity =>
      {
        entity.HasKey(e => e.ID);
        entity.Property(e => e.Name).IsRequired();
      });
    }
  }
}