using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Customer.Domain.AggregatesModel.CustomerAggregate;
using System;
using Customer.Domain.AggregatesModel.GeographicalAggregate;

namespace Customer.Infrastructure.EntityConfigurations
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            // Use Fluent API to configure  

            // Map entities to tables 
            builder.ToTable("customers", CustomerDBContext.DEFAULT_SCHEMA);

            // Configure Primary Keys 
            builder
                .HasKey(o => o.Id)
                .HasName("PK_Customer");

            builder.OwnsOne(o => o.Address);

            // Configure índexes
            builder
                .HasIndex(p => p.DocumentNumber)
                .IsUnique(true)
                .HasDatabaseName("Idx_DocumentNumber");

            // Set fields
            builder
                .Property(b => b.DocumentNumber)
                .HasMaxLength(12)
                .IsRequired();

            builder
                .Property<string>("_documentType")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("DocumentType")
                .HasMaxLength(1)
                .IsRequired(true);

            builder
                .Property<string>("_firstName")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("FirstName")
                .HasMaxLength(45)
                .IsRequired(true);

            builder
                .Property<string>("_lastName")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("LastName")
                .HasMaxLength(45)
                .IsRequired(true);

            builder
                .Property<string>("_bussinesName")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("BussinesName")
                .HasMaxLength(75)
                .IsRequired();

            builder
                .Property<string>("_mainPhone")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("MainPhone")
                .HasMaxLength(8)
                .IsRequired();

            builder
                .Property<string>("_cellPhone")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CellPhone")
                .HasMaxLength(8)
                .IsRequired();

            builder
                .Property<string>("_otherPhone")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("OtherPhone")
                .HasMaxLength(8)
                .IsRequired();

            builder
                .Property<string>("_email")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Email")
                .HasMaxLength(45)
                .IsRequired();

            builder
                .Property<bool>("_isActive")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("IsActive")
                .HasDefaultValue<bool>(true)
                .IsRequired(true);

            builder
                .Property<DateTime>("_createDate")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CreateDate")
                .IsRequired();

            builder
                .Property<DateTime>("_lastUpdate")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("LastUpdate")
                .IsRequired();

            builder
                .Property<int?>("_territoryId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("TerritoryId")
                .IsRequired(false);

            builder
                .HasOne<Geographical>()
                .WithMany()
                .HasForeignKey("_territoryId")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
