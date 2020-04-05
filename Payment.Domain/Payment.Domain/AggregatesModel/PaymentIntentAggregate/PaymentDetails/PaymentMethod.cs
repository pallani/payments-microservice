using Payment.Domain.SeedWork;

namespace Payment.Domain.AggregatesModel.PaymentIntentAggregate
{
	public class PaymentMethod : Enumeration
	{
		public static PaymentMethod FAST = new PaymentMethod(1, "FAST", "Fast And Secure Transfer");
		public static PaymentMethod Cash = new PaymentMethod(2, "CSH", "Cash");
		public static PaymentMethod CashCard = new PaymentMethod(3, "CCD", "Cash Card");
		public static PaymentMethod Cheque = new PaymentMethod(4, "CHQ", "Cheque");
		public static PaymentMethod CashierOrder = new PaymentMethod(5, "CSO", "Cashier Order");
		public static PaymentMethod ENets = new PaymentMethod(6, "ENets", "Electronic Network for Electronic Transfers");
		public static PaymentMethod Nets = new PaymentMethod(7, "NETS", "Network for Electronic Transfers");
		public static PaymentMethod Giro = new PaymentMethod(8, "Giro", "Giro Deduction");
		public static PaymentMethod IBG = new PaymentMethod(9, "IBG", "InterBank Giro");
		public static PaymentMethod IBankFundTransfer = new PaymentMethod(10, "FundTransfer", "Internet Banking Fund Transfer");
		public static PaymentMethod TT = new PaymentMethod(11, "TT", "Telegraphic Transfer");
		public static PaymentMethod PayNow = new PaymentMethod(12, "PayNow", "PayNow");

		public string Description { get; }

		public PaymentMethod(int id, string name, string description) : base(id, name)
		{
			Description = description;
		}
	}
}