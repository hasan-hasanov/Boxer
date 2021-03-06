﻿using Boxer.Args.ConfigArgs;
using Boxer.Args.ConfigArgs.Parsers;
using Boxer.Args.Factories;
using Boxer.Args.ScriptArgs;
using Boxer.Args.ScriptArgs.Parsers;
using Boxer.Args.SharedArgs;
using Boxer.Args.SharedArgs.Parsers;
using Boxer.Args.Verbs;
using Boxer.Args.Verbs.Parsers;
using Boxer.Handlers;
using Boxer.Handlers.Sandbox;
using Boxer.Parser;
using Microsoft.Extensions.DependencyInjection;
using ScoopBox;

namespace Boxer.DIC
{
    public static class DependendencyResolver
    {
        public static ServiceCollection RegisterConcreteTypes(this ServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICommandLineArgsParser, CommandLineArgsParser>();
            serviceCollection.AddScoped<IVerbParserFactory>(serviceProvider =>
            {
                return new VerbParserFactory()
                {
                    { new ScriptVerb(), new ScriptVerbParser(new ArgParserFactory()
                        {
                            { new FileScriptArg(), new FileScriptArgParser() },
                            { new ChocolateyScriptArg(), new ChocolateyArgParser()},
                            { new ScoopScriptArg(), new ScoopScriptArgsParser()},
                            { new LiteralScriptArg(), new LiteralScriptArgParser()},
                            { new HelpArg(), new HelpArgParser()}
                        },
                        serviceProvider.GetService<IHandler<SandboxRequest>>()) },

                    { new ConfigVerb(), new ConfigVerbParser(new ArgParserFactory()
                        {
                            { new FileArg(), new FileArgParser()},
                            { new HelpArg(), new HelpArgParser()}
                        },
                        serviceProvider.GetService<IHandler<SandboxRequest>>()) },

                    { new VersionVerb(), new VersionVerbParser(new ArgParserFactory()
                        {
                            { new HelpArg(), new HelpArgParser()}
                        })
                    },

                    { new HelpVerb(), new HelpVerbParser() },
                };
            });
            serviceCollection.AddScoped<IHandler<SandboxRequest>, SandboxHandler>();
            serviceCollection.AddScoped<ISandbox, Sandbox>();

            return serviceCollection;
        }
    }
}
