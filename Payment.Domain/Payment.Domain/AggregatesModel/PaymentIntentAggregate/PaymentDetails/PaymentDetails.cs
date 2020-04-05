using Payment.Domain.SeedWork;
using FluentValidation.Results;
using Payment.Domain.Exceptions;
using Payment.Domain.AggregatesModel.PaymentIntentAggregate.Validators;

namespace Payment.Domain.AggregatesModel.PaymentIntentAggregate
{
  public abstract class PaymentDetails : Entity
	{
		public uint AmountInCents { get; protected set; }
		public string Description { get; protected set; }

		private readonly string Method;
		public PaymentMethod GetPaymentMethod => Enumeration.FromDisplayName<PaymentMethod>(Method);

		private readonly string Source;
		public PaymentSource GetPaymentSource => Enumeration.FromDisplayName<PaymentSource>(Source);

		protected PaymentDetails() {}

		public PaymentDetails(int id, uint amountInCents, string description, ushort methodId, ushort sourceId)
		{
			Id = id;
			AmountInCents = amountInCents;
			Description = description;
			Method = Enumeration.FromValue<PaymentMethod>(methodId).Name;
			Source = Enumeration.FromValue<PaymentSource>(sourceId).Name;

			PaymentDetailsValidator validator = new PaymentDetailsValidator();
			ValidationResult results = validator.Validate(this);

			if (!results.IsValid)
			{
				throw new PaymentIntentDomainException(results.ToString());
			}
		}
	}
}
