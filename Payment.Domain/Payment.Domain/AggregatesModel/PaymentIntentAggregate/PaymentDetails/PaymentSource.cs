using Payment.Domain.SeedWork;

namespace Payment.Domain.AggregatesModel.PaymentIntentAggregate
{
	public class PaymentSource : Enumeration
	{
		public static PaymentSource DBS = new PaymentSource(1, "DBS", "Development Bank of Singapore");
		public static PaymentSource POSB = new PaymentSource(2, "POSB", "Post Office Savings Bank");
		public static PaymentSource OCBC = new PaymentSource(3, "OCBC", "Oversea Chinese Banking Corporation");
		public static PaymentSource UOB = new PaymentSource(4, "UOB", "United Overseas Bank");
		public static PaymentSource SCB = new PaymentSource(5, "SCB", "Standard Charted Bank");
		public static PaymentSource CitiBank = new PaymentSource(6, "Citi", "CitiBank");
		public static PaymentSource HSBC = new PaymentSource(7, "Hongkong and Shanghai Banking Corporation", "HSBC");
		public static PaymentSource BOC = new PaymentSource(8, "BOC", "Bank Of China");
		public static PaymentSource ICBC = new PaymentSource(9, "ICBC", "Industrial and Commercial Bank of China");
		public static PaymentSource CIMB = new PaymentSource(10, "CIMB", "Commerce International Merchant Bankers");
		public static PaymentSource MayBank = new PaymentSource(11, "MayBank", "MayBank");
		public static PaymentSource OverseasBank = new PaymentSource(12, "Overseas", "Overseas Bank");
		public static PaymentSource AXSEStation = new PaymentSource(13, "AXS-E-Station", "AXS Online Web Payment Station");
		public static PaymentSource AXSMobile = new PaymentSource(14, "AXS-M-Station", "AXS Mobile App Payment Station");
		public static PaymentSource AXSKiosk = new PaymentSource(15, "AXS-Station", "AXS Physical Kiosk Station");
		public static PaymentSource ServiceBureau = new PaymentSource(16, "SBR","Service Bureau");
		public static PaymentSource HDB = new PaymentSource(17,"HDB", "Housing And Development Board");
		public static PaymentSource JTC = new PaymentSource(18, "JTC", "Jurong Town Corporation");

		public string Description { get; }

		public PaymentSource(int id, string name, string description) : base(id, name)
		{
			Description = description;
		}
	}
}
