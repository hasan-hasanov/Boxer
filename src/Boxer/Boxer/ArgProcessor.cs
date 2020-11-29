using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boxer
{
    public class ArgProcessor : Dictionary<string[], Func<string, Task>>
    {
        public Func<string, Task> this[string key]
        {
            get
            {
                var dictionaryKey = base.Keys.First(k => k.Contains(key));
                return base[dictionaryKey];
            }
        }
    }
}
