namespace EFCore.Models;

public class OrdersProducts
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    
    public byte Amount { get; set; }
}