using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workshop.Damain.AggregatesModel.ParameterAggregate;

namespace Workshop.Infrastructure.EntityConfigurations
{
    class ModelEntityTypeConfiguration
       : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            // Use Fluent API to configure  

            // Map entities to tables 
            builder.ToTable("models", WorkshopDBContext.DEFAULT_SCHEMA);

            // Configure Primary Keys 
            builder
                .HasKey(o => o.Id)
                .HasName("PK_Model");

            builder
                .Property<string>("_description")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Description")
                .HasMaxLength(45)
                .IsRequired(true);
        }
    }
}
