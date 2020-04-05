using System;

namespace Payment.Domain.Exceptions
{
  public class PaymentIntentDomainException : Exception
  {
    public PaymentIntentDomainException() {}
    public PaymentIntentDomainException(string message) : base(message) {}
    public PaymentIntentDomainException(string message, Exception innerException) : base(message, innerException) {}
  }
}
