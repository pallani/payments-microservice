using System;
using System.Threading;
using System.Threading.Tasks;

namespace Payment.Domain.SeedWork
{
    public interface IUnitOfWork : IDisposable
		{
			public Task<bool> SaveEntityChangesAsync(CancellationToken cancellationToken = default);
		}
}