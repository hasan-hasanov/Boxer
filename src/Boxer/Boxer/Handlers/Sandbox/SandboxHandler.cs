using ScoopBox;
using System.Threading;
using System.Threading.Tasks;

namespace Boxer.Handlers.Sandbox
{
    public class SandboxHandler : IHandler<SandboxRequest>
    {
        private readonly ISandbox _sandbox;

        public SandboxHandler(ISandbox sandbox)
        {
            _sandbox = sandbox;
        }

        public async Task HandleAsync(SandboxRequest command, CancellationToken cancellationToken = default)
        {
            await _sandbox.Run(command.Scripts, cancellationToken);
        }
    }
}
