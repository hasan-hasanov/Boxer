using System.Collections.Generic;
using System.Linq;

namespace Boxer.Args.Factories
{
    public class ArgParserFactory : Dictionary<IArg, IArgParser>, IArgParserFactory
    {
        public IArgParser this[string key]
        {
            get
            {
                var dictionaryKey = Keys.FirstOrDefault(k => k.LongName == key || k.ShortName == key);
                return dictionaryKey == null ? null : base[dictionaryKey];
            }
        }
    }
}
