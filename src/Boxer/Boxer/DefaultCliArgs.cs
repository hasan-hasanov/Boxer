using System;
using System.Threading.Tasks;

namespace Boxer
{
    public class DefaultCliArgs : ICommandLineArgs
    {
        private readonly ArgProcessor _argProcessor;

        public DefaultCliArgs()
        {
            _argProcessor = new ArgProcessor()
            {
                { new string[] { "-f", "--file-script" }, (arg) => { Console.WriteLine(arg); return Task.CompletedTask; } },
                { new string[] { "--chocolatey" }, null },
                { new string[] { "--scoop" }, null },
                { new string[] { "-s", "--literal-script" }, null },
            };
        }

        public ArgProcessor Processor => _argProcessor;
    }
}
