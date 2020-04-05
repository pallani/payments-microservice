using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payment.Domain.AggregatesModel.PaymentIntentAggregate;

namespace Payment.Infrastructure.EntityConfigurations
{
  class PaymentIntentConfiguration : IEntityTypeConfiguration<PaymentIntent>
  {
    public void Configure(EntityTypeBuilder<PaymentIntent> configuration)
    {
      configuration.ToTable("PaymentIntent");

			// primary key configuration
			configuration.HasKey(pi => pi.Id);
      configuration.Property(pi => pi.Id).HasColumnName("Id");

			// relationship configuration
			configuration
				.HasOne(pi => pi.PaymentDetails)
				.WithOne()
				.HasForeignKey<PaymentDetails>("FK_PaymentIntentId");

			//column configuration
			configuration
				.Property(pi => pi.PaymentReferenceNumber)
				.IsRequired(true);

			configuration
				.Property<string>("Status")
				.IsRequired(true);

			configuration
				.Property(pi => pi.Customer)
				.IsRequired(true);

			configuration
				.Property(pi => pi.CreatedAt)
				.IsRequired(true);

			configuration
				.Property(pi => pi.UpdatedAt);

			configuration
				.Property(pi => pi.CancellationAt);

			configuration
				.Property(pi => pi.CancellationReason);

			configuration
				.Property(pi => pi.FailureAt);

			configuration
				.Property(pi => pi.FailureReason);
		}
	}
}


