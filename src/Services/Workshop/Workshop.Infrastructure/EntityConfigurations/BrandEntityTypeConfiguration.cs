using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop.Damain.AggregatesModel.ParameterAggregate;

namespace Workshop.Infrastructure.EntityConfigurations
{
    class BrandEntityTypeConfiguration
        : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            // Use Fluent API to configure  

            // Map entities to tables 
            builder.ToTable("brands", WorkshopDBContext.DEFAULT_SCHEMA);

            // Configure Primary Keys 
            builder
                .HasKey(o => o.Id)
                .HasName("PK_Brand");

            builder
                .Property<string>("_name")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Name")
                .HasMaxLength(45)
                .IsRequired(true);
        }
    }
}
