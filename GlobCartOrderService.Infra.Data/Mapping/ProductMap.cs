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
    internal class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(prop => prop.ProductId)
                .HasColumnType("varchar(40)")
                .HasMaxLength(40);

            builder.Property(prop => prop.ProductName)
                .HasColumnType("varchar(150)")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(prop => prop.UnitPrice)
                .HasColumnType("decimal(10,3)")
                .IsRequired();

            builder.Property(prop => prop.ProductCreated)
                .HasColumnType("Date");

            builder.Property(prop => prop.UpdatedAt)
                .HasColumnType("Date");
        }
    }
}
