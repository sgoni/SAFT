using Customer.Domain.AggregatesModel.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer.Infrastructure.EntityConfigurations
{
    public class AddressEntityTypeConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            // Use Fluent API to configure  

            // Map entities to tables 
            builder.ToTable("addresses", CustomerDBContext.DEFAULT_SCHEMA);

            builder.HasKey(o => o.Id).HasName("PK_Address"); ;

            builder.Property(o => o.Id).UseHiLo("addressseq");

            builder
                .Property<string>("_address1")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Address1")
                .HasMaxLength(250)
                .IsRequired();

            builder
                .Property<string>("_address2")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Address2")
                .HasMaxLength(250)
                .IsRequired();

            builder
                .Property<string>("_district")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("District")
                .HasMaxLength(45)
                .IsRequired();

            builder
                .Property<string>("_street")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Street")
                .HasMaxLength(45)
                .IsRequired();

            builder
                .Property<string>("_city")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("City")
                .HasMaxLength(45)
                .IsRequired(true);

            builder
                .Property<string>("_state")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("State")
                .HasMaxLength(45)
                .IsRequired(true);

            builder
                .Property<string>("_country")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Country")
                .HasMaxLength(45)
                .IsRequired(true);

            builder
                .Property<string>("_zipCode")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ZipCode")
                .HasMaxLength(10)
                .IsRequired();

            builder
                .Property<string>("_longitude")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Longitude")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property<string>("_latitude")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Latitude")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
