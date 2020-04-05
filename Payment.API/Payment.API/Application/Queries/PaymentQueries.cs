using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Payment.Domain.AggregatesModel.PaymentIntentAggregate;

namespace Payment.API.Application.Queries
{
		public class PaymentQueries : IPaymentQueries
	{
			private readonly ILogger<PaymentQueries> _logger;
			private readonly IPaymentIntentRepository _repository;

			public PaymentQueries(IPaymentIntentRepository repository, ILogger<PaymentQueries> logger)
			{
				_logger = logger;
				_repository = repository;
			}

			public async Task<List<PaymentIntent>> Get()
			{
				List<PaymentIntent> paymentIntents = await _repository.Get();
				return paymentIntents;
			}
		}
}
