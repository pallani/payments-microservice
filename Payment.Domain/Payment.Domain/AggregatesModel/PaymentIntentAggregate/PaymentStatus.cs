using Payment.Domain.SeedWork;

namespace Payment.Domain.AggregatesModel.PaymentIntentAggregate
{
	public class PaymentStatus : Enumeration
	{
		public static PaymentStatus New = new PaymentStatus(1, "New");
		public static PaymentStatus Succeeded = new PaymentStatus(2, "Succeeded");
		public static PaymentStatus Failed = new PaymentStatus(3, "Failed");
		public static PaymentStatus Cancelled = new PaymentStatus(4, "Cancelled");

		public PaymentStatus(int id, string name) : base(id, name) { }
	}
}