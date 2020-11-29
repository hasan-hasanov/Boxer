namespace Boxer.Args.VerbArgs
{
    public class ScriptArg : IArg
    {
        public ScriptArg()
        {
            LongName = "script";

            //TODO: Improve help
            Help = "Use this to execute aplications in sandbox";
        }

        public string ShortName { get; }

        public string LongName { get; }

        public string Help { get; }
    }
}
