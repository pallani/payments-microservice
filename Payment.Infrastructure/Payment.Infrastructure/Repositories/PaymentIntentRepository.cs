using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Payment.Domain.SeedWork;
using Payment.Domain.AggregatesModel.PaymentIntentAggregate;

namespace Payment.Infrastructure.Repositories
{
	public class PaymentIntentRepository : IPaymentIntentRepository
	{
		private readonly PaymentContext _context;

		public IUnitOfWork UnitOfWork
		{
			get { return _context; }
		}

		public PaymentIntentRepository(PaymentContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public async Task<List<PaymentIntent>> Get()
		{
			return await _context.PaymentIntents.Include(pi => pi.PaymentDetails).ToListAsync();
		}

		public async Task<PaymentIntent> GetById(string id)
		{
			return await _context.PaymentIntents.FindAsync(id);
		}

		public async void Add(PaymentIntent paymentIntent)
		{ 
			await _context.PaymentIntents.AddAsync(paymentIntent);
		}

		public PaymentIntent Update(PaymentIntent paymentIntentChanges)
		{
			var paymentIntent = _context.PaymentIntents.Attach(paymentIntentChanges);
			paymentIntent.State = EntityState.Modified;

			return paymentIntentChanges;
		}
  }
}
