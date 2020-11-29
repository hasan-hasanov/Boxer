using System.Collections.Generic;
using System.Linq;

namespace Boxer.Args.Factories
{
    public class VerbParserFactory : Dictionary<IVerb, IVerbParser>, IVerbParserFactory
    {
        public IVerbParser this[string key]
        {
            get
            {
                var dictionaryKey = Keys.FirstOrDefault(k => k.Name == key);
                return dictionaryKey == null ? null : base[dictionaryKey];
            }
        }
    }
}
