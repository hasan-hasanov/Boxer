using ScoopBox.Scripts;
using System.Collections.Generic;

namespace Boxer.Handlers.Sandbox
{
    public class SandboxRequest : IRequest
    {
        public SandboxRequest(List<IScript> scripts)
        {
            Scripts = scripts;
        }

        public List<IScript> Scripts { get; }
    }
}
