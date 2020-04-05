using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payment.Domain.AggregatesModel.PaymentIntentAggregate;

namespace Payment.Infrastructure.EntityConfigurations
{
	public class PaymentDetailsConfiguration : IEntityTypeConfiguration<PaymentDetails>
	{
		public void Configure(EntityTypeBuilder<PaymentDetails> configuration)
		{
			configuration.ToTable("PaymentIntentDetails");

			// primary key configuration
			configuration.HasKey(pid => pid.Id);
			configuration.Property(pid => pid.Id).HasColumnName("Id");

			// column configuration
			configuration
				.HasDiscriminator<string>("Method")
				.HasValue<FASTDetails>("FAST")
				.HasValue<ENetsDetails>("ENets");

			configuration
				.Property<string>("Source")
				.IsRequired(true);

			configuration
				.Property(pid => pid.AmountInCents)
				.IsRequired(true);

			configuration
				.Property(pid => pid.Description);
		}
	}
}