using System;
using System.Collections.Generic;
using System.Linq;

namespace Boxer.Args
{
    public class VerbProcessor : Dictionary<IArg, Action<Stack<string>>>
    {
        public Action<Stack<string>> this[string key]
        {
            get
            {
                var dictionaryKey = Keys.FirstOrDefault(k => k.LongName == key || k.ShortName == key);
                return dictionaryKey == null ? null : base[dictionaryKey];
            }
        }
    }
}
