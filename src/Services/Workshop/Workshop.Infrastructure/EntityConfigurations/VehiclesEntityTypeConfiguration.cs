using Customer.Domain.AggregatesModel.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop.Damain.AggregatesModel.ParameterAggregate;
using Workshop.Damain.Enums;
using Workshop.Domain.AggregatesModel.VehiclesAggregate;

namespace Workshop.Infrastructure.EntityConfigurations
{
    public class VehiclesEntityTypeConfiguration
         : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            // Use Fluent API to configure  

            // Map entities to tables 
            builder.ToTable("vehicles", WorkshopDBContext.DEFAULT_SCHEMA);

            // Configure Primary Keys 
            builder
                .HasKey(o => o.Id)
                .HasName("PK_Vehicle");

            // Configure índexes
            builder
                .HasIndex(v => v.LicensePlate)
                .IsUnique(true)
                .HasDatabaseName("Idx_LicensePlate");

            //builder
            //    .HasIndex(v => v.CustomerRef)
            //    .IsUnique(true)
            //    .HasDatabaseName("Idx_CustomerRef");

            // Set fields
            builder
                .Property(b => b.LicensePlate)
                .HasMaxLength(12)
                .IsRequired(true);

            //builder
            //    .Property<int>(b => b.CustomerRef)
            //    .IsRequired(true);

            builder
                .Property<string>("_engineCode")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("EngineCode")
                .HasMaxLength(17)
                .IsRequired();

            builder
                .Property<string>("_generation")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Generation")
                .HasMaxLength(45)
                .IsRequired();

            builder
                .Property<int?>("_brandRef")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("BrandRef")
                .IsRequired();

            builder
                .Property<int?>("_year")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Year")
                .IsRequired();

            builder
                .Property<int?>("_engineTypeRef")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("EngineTypeRef")
                .IsRequired();

            builder
                .Property<int?>("_transmissionTypeRef")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("TransmissionTypeRef")
                .IsRequired();

            builder
                .Property<int?>("_bodyWorkTypeRef")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("BodyWorkTypeRef")
                .IsRequired();

            builder
                .Property<int?>("_gearboxTypeRef")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("GearboxTypeRef")
                .IsRequired();

            builder
                .Property<float>("_power")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Power")
                .IsRequired();

            builder
                .Property<int>("_numberOfSeats")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("NumberOfSeats")
                .IsRequired();

            builder
                .Property<int>("_numberOfDoors")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("NumberOfDoors")
                .IsRequired();

            builder
                .HasOne<BodyWorkType>()
                .WithMany()
                .HasForeignKey("_bodyWorkTypeRef")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<Brand>()
                .WithMany()
                .HasForeignKey("_brandRef")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<EngineType>()
                .WithMany()
                .HasForeignKey("_engineTypeRef")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<GearBoxType>()
                .WithMany()
                .HasForeignKey("_gearboxTypeRef")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<TransmissionType>()
                .WithMany()
                .HasForeignKey("_transmissionTypeRef")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<Client>()
                .WithMany()
                .HasForeignKey("CustomerRef")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
