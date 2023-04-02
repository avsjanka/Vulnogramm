using Exsample.Models;

namespace Exsample.Data;
using Microsoft.EntityFrameworkCore;

public class Context: DbContext
{
    public Context (DbContextOptions<Context> options) : base(options)
    {
    }
    
    public Context()
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;  Port=5432; Database=Vulnogramm; Username=admin; Password=admin");
    }
    public DbSet<User> User { get; set; }
    public DbSet<Post> Post { get; set; }
    
}