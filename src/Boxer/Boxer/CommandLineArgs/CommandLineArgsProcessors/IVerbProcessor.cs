using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boxer.CommandLineArgs.CommandLineArgsProcessors
{
    public interface IVerbProcessor
    {
        Task Process(Stack<string> args);
    }
}
