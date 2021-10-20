using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop.Damain.AggregatesModel.ParameterAggregate;

namespace Workshop.Infrastructure.EntityConfigurations
{
    class BodyWorkTypeEntityTypeConfiguration 
        : IEntityTypeConfiguration<BodyWorkType>
    {
        public void Configure(EntityTypeBuilder<BodyWorkType> builder)
        {
            // Use Fluent API to configure  

            // Map entities to tables 
            builder.ToTable("bodyWorkTypes", WorkshopDBContext.DEFAULT_SCHEMA);

            // Configure Primary Keys 
            builder
                .Property(ct => ct.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            builder
                .Property<string>("_description")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Description")
                .HasMaxLength(45)
                .IsRequired(true);
        }
    }
}

