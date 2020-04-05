namespace Payment.Domain.AggregatesModel.PaymentIntentAggregate
{
  public class ENetsDetails : PaymentDetails
  {
    public string SwiftCode { get; private set; }
    public string BankCode { get; private set; }
    public string BankBranch { get; private set; }
    public string BankAccountNumber { get; private set; }

    protected ENetsDetails() : base() {}

    public ENetsDetails(string swiftCode, string bankCode, string bankBranch, string bankAccountNumber,
				int id, uint amountInCents, string description, ushort methodId, ushort sourceId)
					: base (id, amountInCents, description, methodId, sourceId)
    {
      SwiftCode = swiftCode;
      BankCode = bankCode;
      BankBranch = bankBranch;
      BankAccountNumber = bankAccountNumber;
    }
  }
}
