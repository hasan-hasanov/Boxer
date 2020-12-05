using Boxer.Args.Factories;
using Boxer.Args.SharedArgs.Parsers;
using Boxer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Boxer.Args.Verbs.Parsers
{
    public class VersionVerbParser : IVerbParser
    {
        private readonly IArgParserFactory _argFactory;

        public VersionVerbParser(IArgParserFactory argFactory)
        {
            _argFactory = argFactory;
        }

        public Task Parse(Stack<string> args)
        {
            string currentArgument = args != null && args.Count > 0 ? args.Pop() : null;
            if (currentArgument != null)
            {
                IArgParser parser = _argFactory[currentArgument];

                if (parser is HelpArgParser)
                {
                    var commandVerb = new VersionVerb();
                    StringBuilder helpBuilder = new StringBuilder()
                        .AppendLine("COMMAND")
                        .AppendLine($"  {commandVerb.Name.First()} - {commandVerb.Help}");

                    Console.WriteLine(helpBuilder);

                    return Task.CompletedTask;
                }
                else
                {
                    StringBuilder helpBuilder = new StringBuilder()
                       .AppendLine($"Argument '{currentArgument}' is not recognized! Try:")
                       .AppendLine()
                       .AppendLine("    boxer version --help");

                    throw new ArgNotFoundException(helpBuilder.ToString());
                }
            }

            string version = Assembly.GetEntryAssembly().GetName().Version.ToString();
            Console.WriteLine(version);

            return Task.CompletedTask;
        }
    }
}
