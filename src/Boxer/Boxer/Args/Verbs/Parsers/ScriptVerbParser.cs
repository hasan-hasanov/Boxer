using Boxer.Args.Factories;
using Boxer.Handlers;
using Boxer.Handlers.Sandbox;
using ScoopBox.Scripts;
using System;
using System.Collections.Generic;
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
            while (args.Count > 0)
            {
                string currentArgument = args.Pop();
                IArgParser parser = _argFactory[currentArgument];

                if (parser == null)
                {
                    throw new ArgumentException("Unrecognized argument!", currentArgument);
                }

                if (parser is HelpVerbParser)
                {
                    parser.Parse(null);
                    return;
                }

                _scripts.AddRange(parser.Parse(args.Pop()));
            }

            await _sandboxHandler.HandleAsync(new SandboxRequest(_scripts));
        }
    }
}
