namespace Boxer.CommandLineArgs.Args.DefaultArgs
{
    public class ChocolateyScriptArg : IArg
    {
        public ChocolateyScriptArg()
        {
            LongName = "--chocolatey";


            Help = "The applications that will be installed using the Chocolatey package manager. Applications should be separated using a comma (,).";
        }

        public string ShortName { get; }

        public string LongName { get; }

        public string Help { get; }
    }
}
