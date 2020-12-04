using Boxer.Args.Factories;
using Boxer.Args.SharedArgs.Parsers;
using Boxer.Exceptions;
using Boxer.Handlers;
using Boxer.Handlers.Sandbox;
using ScoopBox.Scripts;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxer.Args.Verbs.Parsers
{
    public class ConfigVerbParser : IVerbParser
    {
        private readonly List<IScript> _scripts;
        private readonly IArgParserFactory _argParserFactory;
        private readonly IHandler<SandboxRequest> _sandboxHandler;

        public ConfigVerbParser(IArgParserFactory argParserFactory, IHandler<SandboxRequest> sandboxHandler)
        {
            _scripts = new List<IScript>();
            _argParserFactory = argParserFactory;
            _sandboxHandler = sandboxHandler;
        }

        public async Task Parse(Stack<string> args)
        {
            string currentArgument;
            IArgParser argParser;

            if (args.Count == 0)
            {
                args.Push("-h");
            }

            while (args.Count > 0)
            {
                currentArgument = args.Pop();
                argParser = _argParserFactory[currentArgument];

                if (argParser == null)
                {
                    StringBuilder helpBuilder = new StringBuilder()
                        .AppendLine($"Argument '{currentArgument}' is not recognized! Try:")
                        .AppendLine()
                        .AppendLine("    boxer config --help");

                    throw new ArgNotFoundException(helpBuilder.ToString());
                }

                if (argParser is HelpArgParser)
                {
                    argParser.Parse("Boxer.Args.ConfigArgs.IConfigArg;Boxer.Args.Verbs.ConfigVerb");
                    return;
                }

                _scripts.AddRange(argParser.Parse(args.Pop()));
            }

            await _sandboxHandler.HandleAsync(new SandboxRequest(_scripts));
        }
    }
}
