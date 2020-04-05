using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Payment.Domain.AggregatesModel.PaymentIntentAggregate;

namespace Payment.API.Application.Commands
{
  public class CreatePaymentIntentCommandHandler : IRequestHandler<CreateFASTPaymentCommand, bool>
  {
    private readonly IPaymentIntentRepository _repository;

    public CreatePaymentIntentCommandHandler(IPaymentIntentRepository repository)
    {
			_repository = repository;
    }

    public async Task<bool> Handle(CreateFASTPaymentCommand request, CancellationToken cancellationToken)
    {
      PaymentIntent paymentIntent = request.MapPaymentDTOtoDomainObject();

      _repository.Add(paymentIntent);
      await _repository.UnitOfWork.SaveEntityChangesAsync();

      return true;
    }
  }
}
