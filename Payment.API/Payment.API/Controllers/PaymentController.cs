using MediatR;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payment.API.Application.Queries;
using Payment.API.Application.Commands;

namespace StampDuty.API.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class PaymentController : ControllerBase
  {
    private readonly IMediator _mediator;
    private readonly IPaymentQueries _paymentQueries;

    public PaymentController(IMediator mediator, IPaymentQueries paymentQueries)
    {
      _mediator = mediator;
			_paymentQueries = paymentQueries;
    }

		[HttpGet]
		public async Task<IActionResult> GetPayment()
		{ 
			dynamic ls = await _paymentQueries.Get();

			System.Console.WriteLine(ls[0].PaymentDetails.BankAccountNumber);
			return Ok(JsonConvert.SerializeObject(ls));
    }

		[HttpPost]
    public async Task<IActionResult> CreateFASTPayment([FromBody]CreateFASTPaymentCommand command)
    {
			bool isSuccess = await _mediator.Send(command);

			if (isSuccess)
				return Ok();

			return BadRequest();
		}
	}
}
