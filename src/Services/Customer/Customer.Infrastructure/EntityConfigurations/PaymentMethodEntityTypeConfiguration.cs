using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Customer.Domain.AggregatesModel.CustomerAggregate;
using System;
using Customer.Domain.AggregatesModel.BankingAggregate;

namespace Customer.Infrastructure.EntityConfigurations
{
    public class PaymentMethodEntityTypeConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            // Use Fluent API to configure  

            // Map entities to tables 
            builder
                .ToTable("paymentmethods", CustomerDBContext.DEFAULT_SCHEMA);

            builder
                .HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .UseHiLo("paymentseq", CustomerDBContext.DEFAULT_SCHEMA);

            builder
                .Property<string>(p => p.CardNumber)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CardNumber")
                .HasMaxLength(25)
                .IsRequired();

            builder
                .Property<DateTime>("_expiration")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Expiration")
                .HasMaxLength(25)
                .IsRequired();

            builder
                .Property<int>("_cardTypeId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CardTypeId")
                .IsRequired();

            builder
                .Property<int>("_cardTypeId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CardTypeId")
                .IsRequired();

            builder
                .Property<int?>("_bankRef")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("BankRef")
                .IsRequired(false);

            builder.HasOne<Bank>()
                .WithMany()
                // .HasForeignKey("PaymentMethodId")
                .HasForeignKey("_bankRef")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.CardType)
                .WithMany()
                .HasForeignKey("_cardTypeId")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<Client>(s => s.Client)
                .WithMany(p => p.PaymentMethodItems)
                .HasForeignKey(c => c.ClientRef);
        }
    }
}
