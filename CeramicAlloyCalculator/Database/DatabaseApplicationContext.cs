using CeramicAlloyCalculator.Database.Tables;
using Microsoft.EntityFrameworkCore;

namespace CeramicAlloyCalculator.Database;

public class DatabaseApplicationContext : DbContext
{
    public DbSet<MaterialEntity> materials { get; set; }
    public DbSet<UserEntity> users { get; set; }
    
    public DatabaseApplicationContext()
    {
        Database.EnsureCreated();
        Console.WriteLine("Connection to the DB established successfully");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=password");
        base.OnConfiguring(optionsBuilder);
    }
}