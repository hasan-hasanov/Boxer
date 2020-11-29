using ScoopBox.Scripts;
using ScoopBox.Scripts.Materialized;
using ScoopBox.Translators.Powershell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Boxer.Args.ScriptArgs.Parsers
{
    public class FileScriptArgParser : IArgParser
    {
        public List<IScript> Parse(string arg)
        {
            List<IScript> scripts = new List<IScript>();
            string[] filePaths = arg.Split(",", StringSplitOptions.RemoveEmptyEntries);

            // TODO: Determine automatically the extension of the script.
            List<ExternalScript> fileScripts = filePaths.Select(f => new ExternalScript(new FileInfo(f), new PowershellTranslator())).ToList();

            scripts.AddRange(fileScripts);
            return scripts;
        }
    }
}
