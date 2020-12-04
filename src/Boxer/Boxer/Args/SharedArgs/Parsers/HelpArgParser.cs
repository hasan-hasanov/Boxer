using ScoopBox.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boxer.Args.SharedArgs.Parsers
{
    public class HelpArgParser : IArgParser
    {
        public List<IScript> Parse(string arg)
        {
            string[] splitArgs = arg.Split(";");

            Type commandArgsType = Type.GetType(splitArgs[0]);
            Type commandVerbType = Type.GetType(splitArgs[1]);

            IVerb commandVerb = Activator.CreateInstance(commandVerbType) as IVerb;
            IEnumerable<Type> commandArgs = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => commandArgsType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            StringBuilder helpBuilder = new StringBuilder();
            helpBuilder.AppendLine("COMMAND");
            helpBuilder.AppendLine($"  { commandVerb.Name.First() } - {commandVerb.Help}");
            helpBuilder.AppendLine();

            foreach (var commandArg in commandArgs)
            {
                IArg concreteCommandArg = Activator.CreateInstance(commandArg) as IArg;

                if (string.IsNullOrEmpty(concreteCommandArg.ShortName))
                {
                    helpBuilder.AppendLine($"     {concreteCommandArg.LongName} - {concreteCommandArg.Help}");
                }
                else
                {
                    helpBuilder.AppendLine($" {concreteCommandArg.ShortName}, {concreteCommandArg.LongName} - {concreteCommandArg.Help}");
                }
            }

            Console.WriteLine(helpBuilder.ToString());
            return null;
        }
    }
}