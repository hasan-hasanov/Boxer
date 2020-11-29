using System.Threading;
using System.Threading.Tasks;

namespace Boxer.Handlers
{
    public interface IHandler<TRequest>
        where TRequest : IRequest
    {
        Task HandleAsync(TRequest command, CancellationToken cancellationToken = default);
    }
}
