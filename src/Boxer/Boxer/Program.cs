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

namespace Boxer
{
    class Program
    {
        static void Main(string[] args)
        {
            args = new string[] { "-f", @"C:/test.ps1", "--scoop", "git, curl, fiddler", "-s", "Start-Process .", "--chocolatey", "vscode", "-s", "start-process facebook.com", "-f", @"C:/test2.ps1" };

            Stack<string> cliArgs = new Stack<string>(args.Reverse());
            List<IScript> scripts = new List<IScript>();

            while (cliArgs.Count > 0)
            {
                string currentArgument = cliArgs.Pop();
                switch (currentArgument)
                {
                    case "-f":
                        scripts.Add(new ExternalScript(new FileInfo(cliArgs.Pop()), new PowershellTranslator()));
                        break;
                    case "--chocolatey":
                        string[] chocoApps = cliArgs.Pop().Split(",", StringSplitOptions.RemoveEmptyEntries);
                        scripts.Add(new ChocolateyPackageManagerScript(chocoApps));
                        break;
                    case "--scoop":
                        string[] scoopApps = cliArgs.Pop().Split(",", StringSplitOptions.RemoveEmptyEntries);
                        scripts.Add(new ScoopPackageManagerScript(scoopApps));
                        break;
                    case "-s":
                        string[] literalScripts = cliArgs.Pop().Split(";", StringSplitOptions.RemoveEmptyEntries);
                        scripts.Add(new LiteralScript(literalScripts));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
