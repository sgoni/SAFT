using Customer.Domain.AggregatesModel.GeographicalAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer.Infrastructure.EntityConfigurations
{
    class GeographicalEntityTypeConfiguration
          : IEntityTypeConfiguration<Geographical>
    {
        public void Configure(EntityTypeBuilder<Geographical> builder)
        {
            // Use Fluent API to configure  

            // Map entities to tables 
            builder.ToTable("territories", CustomerDBContext.DEFAULT_SCHEMA);

            builder.OwnsOne(o => o.Province);
            builder.OwnsOne(o => o.City);
            builder.OwnsOne(o => o.Distric);
            builder.OwnsOne(o => o.Neighborhood);

            // Configure Primary Keys 
            builder.HasKey(o => o.Id).HasName("PK_territory");

            //builder.Property(o => o.Id).UseHiLo("countryseq");

            builder
                .Property<int>("_codeCountry")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CodeCountry")
                .IsRequired();

            builder
                .Property<string>("_countryName")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CountryName")
                .HasMaxLength(45)
                .IsRequired();
        }
    }
}
