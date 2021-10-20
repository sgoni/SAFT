using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop.Damain.Enums;

namespace Workshop.Infrastructure.EntityConfigurations
{
    class TireTypeEntityTypeConfiguration
       : IEntityTypeConfiguration<TireType>
    {
        public void Configure(EntityTypeBuilder<TireType> builder)
        {
            // Use Fluent API to configure  

            // Map entities to tables 
            builder.ToTable("tireTypes", WorkshopDBContext.DEFAULT_SCHEMA);

            // Configure Primary Keys 
            builder
                .Property(ct => ct.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            builder
                .Property(ct => ct.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
