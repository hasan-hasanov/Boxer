namespace Boxer.Args.VerbArgs
{
    public class ConfigArg : IArg
    {
        public ConfigArg()
        {
            ShortName = "-h";
            LongName = "--help";

            // TODO: Improve help
            Help = "Use this for configuration";
        }

        public string ShortName { get; }

        public string LongName { get; }

        public string Help { get; }
    }
}
