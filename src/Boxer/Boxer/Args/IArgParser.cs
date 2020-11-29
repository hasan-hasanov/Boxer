using ScoopBox.Scripts;
using System.Collections.Generic;

namespace Boxer.Args
{
    public interface IArgParser
    {
        List<IScript> Parse(string arg);
    }
}
