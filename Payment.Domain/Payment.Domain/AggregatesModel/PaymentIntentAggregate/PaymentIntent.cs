using System;
using Payment.Domain.SeedWork;
using Payment.Domain.Exceptions;

namespace Payment.Domain.AggregatesModel.PaymentIntentAggregate
{
	public class PaymentIntent : Entity, IAggregateRoot
	{
		// ID to go by the convention of pi_xxxxxxx for ease of idenfication during troubleshooting across MS
		public string PaymentReferenceNumber { get; private set; }

		private string Status;
		public PaymentStatus GetPaymentStatus => Enumeration.FromDisplayName<PaymentStatus>(Status);

		public PaymentDetails PaymentDetails { get; private set; }
		public string Customer { get; private set; }

		public DateTime CreatedAt { get; private set; }
		public DateTime UpdatedAt { get; private set; }

		public DateTime CancellationAt { get; private set; }
		public string CancellationReason { get; private set; }

		public DateTime FailureAt { get; private set; }
		public string FailureReason { get; private set; }

		// This will help us determined if the record is created by batch or customer using online portal mode
		public string CreatedBy { get; private set; }

		protected PaymentIntent() {}

		public PaymentIntent(string paymentReferenceNumber, PaymentDetails paymentDetails)
		{
			PaymentReferenceNumber = paymentReferenceNumber;
			Status = PaymentStatus.New.Name;
			Customer = "Swee Chin";
			CreatedAt = DateTime.Now;
			CreatedBy = "Swee Chin";
			PaymentDetails = paymentDetails;
		}

		public void SetPaymentStatusToSucceeded()
		{
			if (Status != PaymentStatus.New.Name)
				PaymentStatusChangeException(PaymentStatus.Succeeded);

			Status = PaymentStatus.Succeeded.Name;
			UpdatedAt = DateTime.Now;
		}

		public void SetPaymentStatusToCancelled(string paymentCancellationReason)
		{
			if (Status != PaymentStatus.New.Name)
				PaymentStatusChangeException(PaymentStatus.Cancelled);

			Status = PaymentStatus.Cancelled.Name;
			CancellationReason = paymentCancellationReason;
			CancellationAt = DateTime.Now;
		}

		public void SetPaymentStatusToFailed(string paymentFailureReason)
		{
			if (Status != PaymentStatus.New.Name)
				PaymentStatusChangeException(PaymentStatus.Failed);

			Status = PaymentStatus.Failed.Name;
			FailureReason = paymentFailureReason;
			FailureAt = DateTime.Now;
		}

		private void PaymentStatusChangeException(PaymentStatus paymentStatusToChange)
		{
			throw new PaymentIntentDomainException(
				$"It is not possible to change the payment intent status" +
					$" from { GetPaymentStatus.Name } to { paymentStatusToChange.Name }."
			);
		}

	}
}