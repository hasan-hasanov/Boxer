namespace Boxer.Args.DefaultArgs
{
    public class LiteralScriptArg : IArg
    {
        public LiteralScriptArg()
        {
            ShortName = "-s";
            LongName = "--literal-script";

            // TODO: Improve help for the parameter
            Help = "Represents a single powershell command.";
        }

        public string ShortName { get; }

        public string LongName { get; }

        public string Help { get; }
    }
}
