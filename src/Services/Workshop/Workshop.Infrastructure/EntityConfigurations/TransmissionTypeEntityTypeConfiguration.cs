using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop.Damain.Enums;

namespace Workshop.Infrastructure.EntityConfigurations
{
    public class TransmissionTypeEntityTypeConfiguration
        : IEntityTypeConfiguration<TransmissionType>
    {
        public void Configure(EntityTypeBuilder<TransmissionType> builder)
        {
            // Use Fluent API to configure  

            // Map entities to tables 
            builder.ToTable("transmissionTypes", WorkshopDBContext.DEFAULT_SCHEMA);

            // Configure Primary Keys 
            builder
                .Property(ct => ct.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(ct => ct.Name)
                .HasMaxLength(200)
                .IsRequired();
        }

    }
}
