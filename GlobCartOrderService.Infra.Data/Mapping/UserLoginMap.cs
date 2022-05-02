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
    public class UserLoginMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(prop => prop.Name)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property<string>(prop => prop.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(prop => prop.Password)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
