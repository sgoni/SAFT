using Customer.Domain.AggregatesModel.BankingAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Infrastructure.EntityConfigurations
{
    class BankingEntityTypeConfiguration
        : IEntityTypeConfiguration<Bank>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Bank> builder)
        {
            // Use Fluent API to configure  

            // Map entities to tables 
            builder.ToTable("banks", CustomerDBContext.DEFAULT_SCHEMA);

            // Configure Primary Keys 
            builder.HasKey(o => o.Id).HasName("PK_bank");

            builder.Property(o => o.Id).UseHiLo("bankitemseq");

            // Configure  índexes
            builder
                .HasIndex(p => p.Name)
                .IsUnique(true)
                .HasDatabaseName("Idx_BankName");

            builder
                .Property<string>(p => p.Name)
                .HasMaxLength(45)
                .IsRequired(true);

            builder
                .Property<string>("_description")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Description")
                .HasMaxLength(150)
                .IsRequired(false);

            builder
                .Property<string>("_phone")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Phone")
                .HasMaxLength(12)
                .IsRequired(false);
        }
    }
}
