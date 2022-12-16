using EFCore.Interfaces;

namespace EFCore.Models;

public class Customer : IBaseEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }

    public virtual List<Order> Orders { get; set; } = new List<Order>();
}