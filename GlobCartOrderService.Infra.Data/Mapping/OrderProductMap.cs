using GlobCartOrderService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobCartOrderService.Infra.Data.Mapping
{
    public class OrderProductMap : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.Property(prop => prop.Id)
                .HasColumnName("Id");

            builder.Property(prop => prop.ProductId)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(prop => prop.ProductName)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(prop => prop.Quantity)
                .IsRequired();

            builder.Property(prop => prop.UnitPrice)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(prop => prop.Total)
                .HasPrecision(18, 2)
                .IsRequired();
        }
    }
}
