using System.Reflection;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Interfaces;

public interface IAppDbContext
{
    public DbSet<Courier> Couriers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    public int SaveChanges();
}