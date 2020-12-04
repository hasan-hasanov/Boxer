using Boxer.Models;
using ScoopBox.Scripts;
using ScoopBox.Scripts.Materialized;
using ScoopBox.Scripts.PackageManagers.Chocolatey;
using ScoopBox.Scripts.PackageManagers.Scoop;
using ScoopBox.Scripts.UnMaterialized;
using ScoopBox.Translators.Powershell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Boxer.Args.ConfigArgs.Parsers
{
    public class FileArgParser : IArgParser
    {
        private readonly Dictionary<string, Func<Configuration, List<IScript>>> _configurationFactory;
        private readonly Func<string, string> _readAllText;

        public FileArgParser()
            : this(
                  new Dictionary<string, Func<Configuration, List<IScript>>>()
                  {
                      { "FILE", config => new List<IScript>(config.Args.Select(r => new ExternalScript(new FileInfo(r), new PowershellTranslator()))) },
                      { "CHOCOLATEY", config => new List<IScript>() { new ChocolateyPackageManagerScript(config.Args) } },
                      { "SCOOP", config => new List<IScript>() { new ScoopPackageManagerScript(config.Args) } },
                      { "LITERAL", config => new List<IScript>(config.Args.Select(r => new LiteralScript(config.Args))) },
                  },
                  path => File.ReadAllText(path))
        {
        }

        internal FileArgParser(
            Dictionary<string, Func<Configuration, List<IScript>>> configurationFactory,
            Func<string, string> readAllText)
        {
            _configurationFactory = configurationFactory;
            _readAllText = readAllText;
        }

        public List<IScript> Parse(string arg)
        {
            List<IScript> scripts = new List<IScript>();
            List<Configuration> fileContent = new List<Configuration>();

            string json = _readAllText(arg);
            fileContent = JsonSerializer.Deserialize<List<Configuration>>(json);

            foreach (var row in fileContent)
            {
                scripts.AddRange(_configurationFactory[row.Type.ToUpper()].Invoke(row));
            }

            return scripts;
        }
    }
}
