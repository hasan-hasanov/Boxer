namespace Boxer.Args.ConfigArgs
{
    public class ConfigArg : IConfigArg
    {
        public ConfigArg()
        {
            ShortName = "-c";
            LongName = "--config-file";

            Help = "Path to the config file.";
        }

        public string ShortName { get; }

        public string LongName { get; }

        public string Help { get; }
    }
}
