namespace Boxer.CommandLineArgs.Args.DefaultArgs
{
    public class ScoopScriptArg : IArg
    {
        public ScoopScriptArg()
        {
            LongName = "--scoop";


            Help = "The applications that will be installed using the Scoop package manager. Applications should be separated using a comma (,).";
        }

        public string ShortName { get; }

        public string LongName { get; }

        public string Help { get; }
    }
}
