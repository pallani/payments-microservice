using System;
using MediatR;
using Payment.Domain.AggregatesModel.PaymentIntentAggregate;

namespace Payment.API.Application.Commands
{
	public class CreateFASTPaymentCommand : IRequest<bool>
	{
		public string PaymentReferenceNumber { get; set; }
		public string BankAccountNumber { get; set; }
		public uint AmountInCents { get; set; }
		public string Description { get; set; }
		public ushort PaymentMethodId { get; set; }
		public ushort PaymentSourceId { get; set; }
	}

	public static class CreateFASTPaymentCommandExtensionMethods
	{
		public static PaymentIntent MapPaymentDTOtoDomainObject(this CreateFASTPaymentCommand request)
		{
			return new PaymentIntent(
				request.PaymentReferenceNumber,
				new FASTDetails(
					request.BankAccountNumber,
					new Random().Next(0, 1000000),
					request.AmountInCents,
					request.Description,
					request.PaymentMethodId,
					request.PaymentSourceId
				)
			);
		}
	}
}
