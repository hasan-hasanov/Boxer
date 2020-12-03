using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxer.Args.Verbs.Parsers
{
    public class HelpVerbParser : IVerbParser
    {
        private readonly IList<IVerb> _verbs;

        public HelpVerbParser()
        {
            IEnumerable<Type> verbTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(IVerb).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            _verbs = new List<IVerb>(verbTypes.Select(v => (IVerb)Activator.CreateInstance(v)));
        }

        public Task Parse(Stack<string> args)
        {
            IEnumerable<string> commands = _verbs.Where(v => !string.IsNullOrEmpty(v.Help)).Select(v => v.Name.First());

            StringBuilder helpBuilder = new StringBuilder();
            helpBuilder.AppendLine(" Usage: boxer <command>");
            helpBuilder.AppendLine();
            helpBuilder.AppendLine(" Where <command> is one of:");
            helpBuilder.AppendLine($"     {string.Join(", ", commands)}");
            helpBuilder.AppendLine();
            helpBuilder.AppendLine($" boxer <command> -h   quick help on <command>");

            Console.WriteLine(helpBuilder);

            return Task.CompletedTask;
        }
    }
}
