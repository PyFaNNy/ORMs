using EFCore.Interfaces;

namespace EFCore.Models;

public class Courier : IBaseEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }

    public virtual List<DeliveryList> Deliveries { get; set; } = new List<DeliveryList>();
}