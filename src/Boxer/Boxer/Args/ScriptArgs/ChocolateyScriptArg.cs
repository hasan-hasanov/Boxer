namespace Boxer.Args.ScriptArgs
{
    public class ChocolateyScriptArg : IScriptArg
    {
        public ChocolateyScriptArg()
        {
            LongName = "--chocolatey";
            Help = "Applications that will be installed with Chocolatey, should be separated by comma (,).";
        }

        public string ShortName { get; }

        public string LongName { get; }

        public string Help { get; }
    }
}
