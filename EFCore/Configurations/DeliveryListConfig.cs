using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Configurations;

public class DeliveryListConfig : IEntityTypeConfiguration<DeliveryList>
{
    public void Configure(EntityTypeBuilder<DeliveryList> builder)
    {
        builder.ToTable("DeliveryList", "delivery");

        builder.Property(x => x.OrderId)
            .IsRequired();
        
        builder.Property(x => x.CourierId)
            .IsRequired();
    }
}