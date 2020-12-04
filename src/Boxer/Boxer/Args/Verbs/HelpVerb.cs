namespace Boxer.Args.Verbs
{
    public class HelpVerb : IVerb
    {
        public HelpVerb()
        {
            Name = new[] { "help", "--help", "-h" };
        }

        public string[] Name { get; }

        public string Help { get; }
    }
}
