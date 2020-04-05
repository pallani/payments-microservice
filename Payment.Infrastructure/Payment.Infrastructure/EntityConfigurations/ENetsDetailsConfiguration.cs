using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payment.Domain.AggregatesModel.PaymentIntentAggregate;

namespace Payment.Infrastructure.EntityConfigurations
{
	public class ENetsDetailsConfiguration : IEntityTypeConfiguration<ENetsDetails>
	{
		public void Configure(EntityTypeBuilder<ENetsDetails> configuration)
		{
			//column configuration
			configuration
				.Property<string>("SwiftCode")
				.HasColumnName("ENets_SwiftCode");

			configuration
				.Property<string>("BankCode")
				.HasColumnName("ENets_BankCode");

			configuration
				.Property<string>("BankBranch")
				.HasColumnName("ENets_BankBranch");

			configuration
				.Property<string>("BankAccountNumber")
				.HasColumnName("ENets_BankAccountNumber");
		}
	}
}