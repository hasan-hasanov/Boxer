namespace Boxer.Args.SharedArgs
{
    public class HelpArg : IArg
    {
        public HelpArg()
        {
            ShortName = "-h";
            LongName = "--help";
        }

        public string ShortName { get; }

        public string LongName { get; }

        public string Help { get; }
    }
}
