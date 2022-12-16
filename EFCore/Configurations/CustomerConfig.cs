using EFCore.Extensions;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Configurations;

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers", "delivery");

        builder.Property(x => x.PhoneNumber)
            .HasPhoneMaxLength()
            .IsRequired();

        builder.Property(x => x.FirstName)
            .HasMediumMaxLength()
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasMediumMaxLength()
            .IsRequired();
    }
}