namespace Payment.Domain.AggregatesModel.PaymentIntentAggregate
{
  public class FASTDetails : PaymentDetails
  {
		public string BankAccountNumber { get; private set; }

		protected FASTDetails() : base() {}

    public FASTDetails(string bankAccountNumber,
				int id, uint amountInCents, string description, ushort methodId, ushort sourceId)
					: base(id, amountInCents, description, methodId, sourceId)
    {
      BankAccountNumber = bankAccountNumber;
    }
  }
}
