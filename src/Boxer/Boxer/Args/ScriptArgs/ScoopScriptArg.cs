namespace Boxer.Args.ScriptArgs
{
    public class ScoopScriptArg : IArg
    {
        public ScoopScriptArg()
        {
            LongName = "--scoop";
            Help = "Applications that will be installed with Scoop, should be separated by comma (,).";
        }

        public string ShortName { get; }

        public string LongName { get; }

        public string Help { get; }
    }
}
