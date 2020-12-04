using Boxer.DIC;
using Boxer.Exceptions;
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

            try
            {
                await parser.Parse(args);
            }
            catch (Exception ex)
                when (ex is VerbNotFoundException || ex is ArgNotFoundException)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}{Environment.NewLine}");

                await parser.Parse(new string[] { "help" });
            }
        }
    }
}
