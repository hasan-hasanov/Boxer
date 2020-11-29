namespace Boxer.Args.Verbs
{
    public class ConfigVerb : IVerb
    {
        public ConfigVerb()
        {
            Name = "config";

            // TODO: Improve help
            Help = "Use this for configuration";
        }

        public string Name { get; }

        public string Help { get; }
    }
}
