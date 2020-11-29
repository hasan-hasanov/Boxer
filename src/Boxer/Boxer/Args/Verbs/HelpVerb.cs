namespace Boxer.Args.Verbs
{
    public class HelpVerb : IVerb
    {
        public HelpVerb()
        {
            Name = "help";
        }

        public string Name { get; }

        public string Help { get; }
    }
}
