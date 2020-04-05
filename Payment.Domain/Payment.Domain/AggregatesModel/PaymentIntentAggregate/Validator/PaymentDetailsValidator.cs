using FluentValidation;
using Payment.Domain.AggregatesModel.PaymentIntentAggregate;

namespace Payment.Domain.AggregatesModel.PaymentIntentAggregate.Validators
{
  public class PaymentDetailsValidator : AbstractValidator<PaymentDetails>
  {
    public PaymentDetailsValidator()
    {
      RuleFor(paymentDetails => paymentDetails.Id).NotNull();
      RuleFor(paymentDetails => paymentDetails.Id).NotEmpty();

      // Payment amount should be at least 100 cents which is $1.00
      // Payment amount cannot be larger than 4,294,967,295 cents which is $42,949,672.95 due to [uint] data type
      RuleFor(paymentDetails => paymentDetails.AmountInCents)
        .Must(amountInCents => amountInCents >= 100)
        .WithMessage("Payment amount should be at least 100 cents which is $1.00")
			  .Must(amountInCents => amountInCents < uint.MaxValue)
        .WithMessage("Payment amount cannot be more than 4,294,967,295 cents which is $42,949,672.95");
    }
  }
}