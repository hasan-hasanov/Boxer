using System;
using System.Collections.Generic;
using System.Linq;

namespace Boxer.Args
{
    public class VerbProcessor : Dictionary<IVerb, Action<Stack<string>>>
    {
        public Action<Stack<string>> this[string key]
        {
            get
            {
                var dictionaryKey = Keys.FirstOrDefault(k => k.Name == key);
                return dictionaryKey == null ? null : base[dictionaryKey];
            }
        }
    }
}
