using ScoopBox.Scripts;
using ScoopBox.Scripts.PackageManagers.Scoop;
using System;
using System.Collections.Generic;

namespace Boxer.Args.ScriptArgs.Parsers
{
    public class ScoopScriptArgsParser : IArgParser
    {
        public List<IScript> Parse(string arg)
        {
            string[] scoopApps = arg.Split(",", StringSplitOptions.RemoveEmptyEntries);
            return new List<IScript>() { new ScoopPackageManagerScript(scoopApps) };
        }
    }
}
