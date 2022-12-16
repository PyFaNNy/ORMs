using System.Reflection;
using EFCore.Interfaces;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.AppContext;

public class AppDbContext : DbContext, IAppDbContext
{
    public DbSet<Courier> Couriers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
    
    public override int SaveChanges()
    {
        var result = base.SaveChanges();

        return result;
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }
}