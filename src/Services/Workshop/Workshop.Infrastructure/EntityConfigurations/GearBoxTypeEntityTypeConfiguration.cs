using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop.Damain.Enums;

namespace Workshop.Infrastructure.EntityConfigurations
{
    class GearBoxTypeEntityTypeConfiguration 
        : IEntityTypeConfiguration<GearBoxType>
    {
        public void Configure(EntityTypeBuilder<GearBoxType> builder)
        {
            // Use Fluent API to configure  

            // Map entities to tables 
            builder.ToTable("gearBoxesTypes", WorkshopDBContext.DEFAULT_SCHEMA);

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