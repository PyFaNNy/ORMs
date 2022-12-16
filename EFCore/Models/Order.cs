using EFCore.Interfaces;

namespace EFCore.Models;

public class Order : IBaseEntity
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime Date { get; set; }
    
    public virtual Customer Customer { get; set; }
    public IList<OrdersProducts> OrdersProducts { get; set; }
}