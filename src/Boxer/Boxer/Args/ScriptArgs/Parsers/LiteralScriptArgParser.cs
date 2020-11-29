using ScoopBox.Scripts;
using ScoopBox.Scripts.UnMaterialized;
using System;
using System.Collections.Generic;

namespace Boxer.Args.ScriptArgs.Parsers
{
    public class LiteralScriptArgParser : IArgParser
    {
        public List<IScript> Parse(string arg)
        {
            string[] scripts = arg.Split(";", StringSplitOptions.RemoveEmptyEntries);
            return new List<IScript>() { new LiteralScript(scripts) };
        }
    }
}
