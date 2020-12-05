using Boxer.Utils;
using ScoopBox.Scripts;
using ScoopBox.Scripts.Materialized;
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

            List<ExternalScript> fileScripts = filePaths.Select(f => new ExternalScript(new FileInfo(f), TranslatorUtils.GetTranslatorByExtensionType(f))).ToList();

            scripts.AddRange(fileScripts);
            return scripts;
        }
    }
}
