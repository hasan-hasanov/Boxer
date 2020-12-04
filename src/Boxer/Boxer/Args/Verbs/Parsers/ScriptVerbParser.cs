using Boxer.Args.Factories;
using Boxer.Args.SharedArgs.Parsers;
using Boxer.Exceptions;
using Boxer.Handlers;
using Boxer.Handlers.Sandbox;
using ScoopBox.Scripts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxer.Args.Verbs.Parsers
{
    public class ScriptVerbParser : IVerbParser
    {
        private readonly List<IScript> _scripts;
        private readonly IArgParserFactory _argFactory;
        private readonly IHandler<SandboxRequest> _sandboxHandler;

        public ScriptVerbParser(IArgParserFactory argFactory, IHandler<SandboxRequest> sandboxHandler)
        {
            _scripts = new List<IScript>();
            _argFactory = argFactory;
            _sandboxHandler = sandboxHandler;
        }

        public async Task Parse(Stack<string> args)
        {
            if (args.Count == 0)
            {
                args.Push("-h");
            }

            while (args.Count > 0)
            {
                string currentArgument = args.Pop();
                IArgParser parser = _argFactory[currentArgument];

                if (parser == null)
                {
                    StringBuilder helpBuilder = new StringBuilder()
                        .AppendLine($"Argument '{currentArgument}' is not recognized! Try:")
                        .AppendLine()
                        .AppendLine("    boxer script --help");

                    throw new ArgNotFoundException(helpBuilder.ToString());
                }

                if (parser is HelpArgParser)
                {
                    parser.Parse("Boxer.Args.ScriptArgs.IScriptArg;Boxer.Args.Verbs.ScriptVerb");
                    return;
                }

                if (args.Count == 0)
                {
                    throw new ArgNotFoundException($"Parameter for argument '{currentArgument}' not found!{Environment.NewLine}");
                }

                _scripts.AddRange(parser.Parse(args.Pop()));
            }

            await _sandboxHandler.HandleAsync(new SandboxRequest(_scripts));
        }
    }
}
