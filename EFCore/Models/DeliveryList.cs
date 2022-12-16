using EFCore.Interfaces;

namespace EFCore.Models;

public class DeliveryList : IBaseEntity
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid CourierId { get; set; }
    
    public virtual Order Order { get; set; }
    public virtual Courier Courier { get; set; }
}