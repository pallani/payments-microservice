using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Payment.Domain.SeedWork;
using Payment.Infrastructure.EntityConfigurations;
using Payment.Domain.AggregatesModel.PaymentIntentAggregate;

namespace Payment.Infrastructure
{
  public class PaymentContext : DbContext, IUnitOfWork
  {
		public DbSet<PaymentIntent> PaymentIntents { get; set; }
		public DbSet<PaymentDetails> PaymentDetails { get; set; }

		public PaymentContext(DbContextOptions<PaymentContext> options) : base(options) {}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new PaymentIntentConfiguration());
			builder.ApplyConfiguration(new PaymentDetailsConfiguration());
			builder.ApplyConfiguration(new FASTDetailsConfiguration());
			builder.ApplyConfiguration(new ENetsDetailsConfiguration());
		}

		public async Task<bool> SaveEntityChangesAsync(CancellationToken cancellationToken = default)
		{
			await base.SaveChangesAsync(cancellationToken);
			return true;
		}
  }
}
