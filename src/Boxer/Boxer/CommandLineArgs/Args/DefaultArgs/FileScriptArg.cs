namespace Boxer.CommandLineArgs.Args.DefaultArgs
{
    public class FileScriptArg : IArg
    {
        public FileScriptArg()
        {
            ShortName = "-f";
            LongName = "--file-script";

            // TODO: Improve help for the parameter
            Help = "Represents the full path of a physical script file including the extension.";
        }

        public string ShortName { get; }

        public string LongName { get; }

        public string Help { get; }
    }
}
