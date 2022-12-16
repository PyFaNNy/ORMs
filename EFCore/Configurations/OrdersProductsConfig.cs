using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Configurations;
 
public class OrdersProductsConfig : IEntityTypeConfiguration<OrdersProducts>
{
    public void Configure(EntityTypeBuilder<OrdersProducts> builder)
    {
        builder.HasKey(op => new {op.OrderId, op.ProductId});

        builder.HasOne<Order>(op => op.Order)
            .WithMany(o => o.OrdersProducts)
            .HasForeignKey(op => op.OrderId);
        
        builder.HasOne<Product>(op => op.Product)
            .WithMany(p => p.OrdersProducts)
            .HasForeignKey(op => op.ProductId);
    }
}