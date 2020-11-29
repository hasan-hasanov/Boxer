using System;
using System.Collections.Generic;
using System.Linq;

namespace Boxer.Args
{
    public class ArgProcessor : Dictionary<IArg, Action<string>>
    {
        public Action<string> this[string key]
        {
            get
            {
                var dictionaryKey = Keys.FirstOrDefault(k => k.LongName == key || k.ShortName == key);
                return dictionaryKey == null ? null : base[dictionaryKey];
            }
        }
    }
}
