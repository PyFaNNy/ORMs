using EFCore.Interfaces;

namespace EFCore.Models;

public class Product : IBaseEntity
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public string Name { get; set; }
    
    public IList<OrdersProducts> OrdersProducts { get; set; }
}