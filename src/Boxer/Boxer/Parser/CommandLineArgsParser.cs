using Boxer.Args;
using Boxer.Args.Factories;
using Boxer.Args.Verbs.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boxer.Parser
{
    public class CommandLineArgsParser : ICommandLineArgsParser
    {
        private readonly IVerbParserFactory _verbParserFactory;

        public CommandLineArgsParser(IVerbParserFactory verbParserFactory)
        {
            _verbParserFactory = verbParserFactory;
        }

        public async Task Parse(string[] args)
        {
            IVerbParser parser = new HelpVerbParser();
            Stack<string> cliArgs = new Stack<string>();

            if (args.Any())
            {
                cliArgs = new Stack<string>(args.Reverse());
                string verb = cliArgs.Pop();

                parser = _verbParserFactory[verb];
                if (parser == null)
                {
                    throw new ArgumentException("Unrecognized verb!", nameof(verb));
                }
            }

            await parser.Parse(cliArgs);
        }
    }
}
