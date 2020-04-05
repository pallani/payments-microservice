using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payment.Domain.AggregatesModel.PaymentIntentAggregate;

namespace Payment.Infrastructure.EntityConfigurations
{
	public class FASTDetailsConfiguration : IEntityTypeConfiguration<FASTDetails>
	{
		public void Configure(EntityTypeBuilder<FASTDetails> configuration)
		{
			//column configuration
			configuration
				.Property<string>("BankAccountNumber")
				.HasColumnName("FAST_BankAccountNumber");
		}
	}
}