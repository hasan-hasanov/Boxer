namespace Boxer.Args.ScriptArgs
{
    public class FileScriptArg : IArg
    {
        public FileScriptArg()
        {
            ShortName = "-f";
            LongName = "--file-script";
            Help = "Full path of the script file including the extension.";
        }

        public string ShortName { get; }

        public string LongName { get; }

        public string Help { get; }
    }
}
