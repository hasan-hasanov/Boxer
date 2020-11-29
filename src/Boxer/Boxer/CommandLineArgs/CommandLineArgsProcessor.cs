using Boxer.CommandLineArgs.CommandLineArgsProcessors;
using Boxer.CommandLineArgs.CommandLineArgsProcessors.Verbs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Boxer.CommandLineArgs
{
    public static class CommandLineArgsProcessor
    {
        private const string configVerb = "CONFIG";
        private const string defaultVerb = "";

        private static readonly IDictionary<string, IVerbProcessor> _verbFactory;

        private static IVerbProcessor _verbProcessor;

        static CommandLineArgsProcessor()
        {
            _verbFactory = new Dictionary<string, IVerbProcessor>()
            {
                { string.Empty, new DefaultVerbArgs() },
                { configVerb, new DefaultVerbArgs() },
            };
        }

        public static void Parse(string[] args)
        {
            Stack<string> cliArgs = new Stack<string>(args.Reverse());

            string verb = cliArgs.Pop();
            switch (verb.ToUpper())
            {
                case configVerb:
                    _verbProcessor = _verbFactory[configVerb];
                    break;
                default:
                    cliArgs.Push(verb);
                    _verbProcessor = _verbFactory[defaultVerb];
                    break;
            }

            _verbProcessor.Process(cliArgs);
        }
    }
}
