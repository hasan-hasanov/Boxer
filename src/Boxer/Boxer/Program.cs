using Boxer.DIC;
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
            IServiceProvider serviceProvider = new ServiceCollection()
               .RegisterConcreteTypes()
               .BuildServiceProvider();

            var parser = serviceProvider.GetService<ICommandLineArgsParser>();
            await parser.Parse(args);
        }
    }
}
