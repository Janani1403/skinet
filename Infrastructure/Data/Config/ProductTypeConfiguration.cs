﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //builder.Property(p => p.Id).ValueGeneratedNever();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Description).HasMaxLength(300);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.HasOne(p => p.ProductBrand ).WithMany()
                .HasForeignKey(p=>p.ProductBrandId);
            builder.HasOne(p => p.ProductType).WithMany()
             .HasForeignKey(p => p.ProductTypeId);
        }
    }
}
