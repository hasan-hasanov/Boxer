using ScoopBox.Scripts;
using ScoopBox.Scripts.PackageManagers.Chocolatey;
using System;
using System.Collections.Generic;

namespace Boxer.Args.ScriptArgs.Parsers
{
    public class ChocolateyArgParser : IArgParser
    {
        public List<IScript> Parse(string arg)
        {
            string[] chocoApps = arg.Split(",", StringSplitOptions.RemoveEmptyEntries);
            return new List<IScript>() { new ChocolateyPackageManagerScript(chocoApps) };
        }
    }
}
