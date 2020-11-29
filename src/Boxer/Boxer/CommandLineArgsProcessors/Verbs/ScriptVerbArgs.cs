﻿using Boxer.Args;
using Boxer.Args.ScriptArgs;
using Boxer.Args.SharedArgs;
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
using System.Text;
using System.Threading.Tasks;

namespace Boxer.CommandLineArgsProcessors.Verbs
{
    public class ScriptVerbArgs : IVerbProcessor
    {
        private readonly List<IScript> _scripts;
        private readonly ArgProcessor _argProcessor;

        public ScriptVerbArgs()
        {
            _scripts = new List<IScript>();

            _argProcessor = new ArgProcessor()
            {
                { new FileScriptArg(), arg => ProcessExternalScript(arg) },
                { new ChocolateyScriptArg(), arg => ProcessChocolateyScript(arg)},
                { new ScoopScriptArg(), arg => ProcessScoopScript(arg)},
                { new LiteralScriptArg(), arg => ProcessLiteralScript(arg)},
                { new HelpArg(), arg => ProcessHelp(arg)}
            };
        }

        public Task Process(Stack<string> args)
        {
            while (args.Count > 0)
            {
                string currentArgument = args.Pop();
                Action<string> argProcessor = _argProcessor[currentArgument];

                if (argProcessor == null)
                {
                    throw new ArgumentException("Unrecognized argument!", currentArgument);
                }

                string argument = args.Count > 0 ? args.Pop() : string.Empty;
                argProcessor.Invoke(argument);
            }

            return Task.CompletedTask;
        }

        private void ProcessExternalScript(string fileScriptArgs)
        {
            string[] filePaths = fileScriptArgs.Split(",", StringSplitOptions.RemoveEmptyEntries);

            // TODO: Determine automatically the extension of the script.
            _scripts.AddRange(filePaths.Select(f => new ExternalScript(new FileInfo(f), new PowershellTranslator())));
        }

        private void ProcessChocolateyScript(string apps)
        {
            string[] chocoApps = apps.Split(",", StringSplitOptions.RemoveEmptyEntries);
            _scripts.Add(new ChocolateyPackageManagerScript(chocoApps));
        }

        private void ProcessScoopScript(string apps)
        {
            string[] scoopApps = apps.Split(",", StringSplitOptions.RemoveEmptyEntries);
            _scripts.Add(new ScoopPackageManagerScript(scoopApps));
        }

        private void ProcessLiteralScript(string literalScripts)
        {
            string[] scripts = literalScripts.Split(";", StringSplitOptions.RemoveEmptyEntries);
            _scripts.Add(new LiteralScript(scripts));
        }

        private void ProcessHelp(string args)
        {
            IEnumerable<IArg> allArgs = _argProcessor.Keys.Where(k => !string.IsNullOrWhiteSpace(k.Help));
            StringBuilder helpBuilder = new StringBuilder();
            foreach (var arg in allArgs)
            {
                if (string.IsNullOrEmpty(arg.ShortName))
                {
                    helpBuilder.AppendLine($"      {arg.LongName} {arg.Help}");
                }
                else
                {
                    helpBuilder.AppendLine($"  {arg.ShortName}, {arg.LongName} {arg.Help}");
                }
            }

            Console.WriteLine(helpBuilder.ToString());
        }
    }
}
