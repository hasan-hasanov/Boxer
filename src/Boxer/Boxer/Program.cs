using Boxer.Configuration;
using Boxer.Parser;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Boxer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // args = new string[] { "script", "-f", @"C:/test.ps1", "--scoop", "git, curl, fiddler", "-s", "Start-Process .", "--chocolatey", "vscode", "-s", "start-process facebook.com", "-f", @"C:/test2.ps1" };
            // args = new string[] { "script", "--scoop", "git, curl, fiddler", "--chocolatey", "vscode" };
            args = new string[] { "help" };

            IServiceProvider serviceProvider = new ServiceCollection()
               .RegisterConcreteTypes()
               .BuildServiceProvider();

            var parser = serviceProvider.GetService<ICommandLineArgsParser>();
            await parser.Parse(args);
        }
    }
}
