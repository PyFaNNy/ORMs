using EFCore.Extensions;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Configurations;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products", "delivery");

        builder.Property(x => x.Name)
            .HasLongMaxLength()
            .IsRequired();

        builder.Property(x => x.Price)
            .IsRequired();
    }
}