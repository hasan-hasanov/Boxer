namespace Boxer.Args.Verbs
{
    public class HelpVerb : IVerb
    {
        public HelpVerb()
        {
            Name = new[] { "help" };
        }

        public string[] Name { get; }

        public string Help { get; }
    }
}
