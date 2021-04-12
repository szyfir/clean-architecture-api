using CleanArchitecture.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure.Persistance.Configurations
{
    public class SalesOrderTypeConfiguration : IEntityTypeConfiguration<SalesOrder>
    {
        public void Configure(EntityTypeBuilder<SalesOrder> builder)
        {
            builder.HasKey(w => w.Id);
            builder.Property(w => w.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
