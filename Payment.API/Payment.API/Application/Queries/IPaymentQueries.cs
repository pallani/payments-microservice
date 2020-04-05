using System.Threading.Tasks;
using System.Collections.Generic;
using Payment.Domain.AggregatesModel.PaymentIntentAggregate;

namespace Payment.API.Application.Queries
{
  public interface IPaymentQueries
  {
    Task<List<PaymentIntent>> Get();
  }
}
