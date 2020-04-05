using Payment.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payment.Domain.AggregatesModel.PaymentIntentAggregate
{
		public interface IPaymentIntentRepository : IRepository<PaymentIntent>
		{
				Task<List<PaymentIntent>> Get();
				Task<PaymentIntent> GetById(string id);
				void Add(PaymentIntent paymentIntent);
				PaymentIntent Update(PaymentIntent paymentIntentChanges);
		}
}
