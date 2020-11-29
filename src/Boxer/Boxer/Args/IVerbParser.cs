using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boxer.Args
{
    public interface IVerbParser
    {
        Task Parse(Stack<string> args);
    }
}
