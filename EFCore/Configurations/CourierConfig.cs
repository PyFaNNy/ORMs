using EFCore.Extensions;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Configurations;

public class CourierConfig : IEntityTypeConfiguration<Courier>
{
    public void Configure(EntityTypeBuilder<Courier> builder)
    {
        builder.ToTable("Couriers", "delivery");

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