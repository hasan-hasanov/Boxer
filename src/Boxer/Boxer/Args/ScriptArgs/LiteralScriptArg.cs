namespace Boxer.Args.ScriptArgs
{
    public class LiteralScriptArg : IScriptArg
    {
        public LiteralScriptArg()
        {
            ShortName = "-s";
            LongName = "--literal-script";
            Help = "Single powershell command.";
        }

        public string ShortName { get; }

        public string LongName { get; }

        public string Help { get; }
    }
}
