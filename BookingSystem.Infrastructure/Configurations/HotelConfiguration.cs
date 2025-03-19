using BookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Configurations;
internal class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
        builder.Property(x => x.Rating).HasDefaultValue(0);

        builder.ComplexProperty(x => x.Address, b =>
        {
            b.Property(p=>p.Street).IsRequired().HasMaxLength(128);
            b.Property(p=>p.PostalCode).IsRequired().HasMaxLength(40);
            b.Property(p => p.Building).IsRequired().HasMaxLength(32);
            b.Property(p=>p.City).IsRequired().HasMaxLength(128);
        });
    }

}
