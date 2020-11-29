using Boxer.Args;
using Boxer.Args.Verbs;
using Boxer.CommandLineArgsProcessors.Verbs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Boxer
{
    public static class CommandLineArgsProcessor
    {
        private static readonly VerbProcessor _verbFactory;

        static CommandLineArgsProcessor()
        {
            _verbFactory = new VerbProcessor()
            {
                { new ScriptVerb(), arg => new ScriptVerbArgs().Process(arg) },
                { new ConfigVerb(), arg => new ConfigVerbArgs().Process(arg) },
                { new HelpVerb(), arg => new HelpVerbArgs().Process(arg) },
            };
        }

        public static void Parse(string[] args)
        {
            Stack<string> cliArgs = new Stack<string>(args.Reverse());
            string verb = cliArgs.Pop();

            var verbProcessor = _verbFactory[verb];
            if (verbProcessor == null)
            {
                throw new ArgumentException("Unrecognized verb!", nameof(verb));
            }

            verbProcessor.Invoke(cliArgs);
        }
    }
}
