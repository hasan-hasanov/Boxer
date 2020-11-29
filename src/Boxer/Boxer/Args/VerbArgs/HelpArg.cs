namespace Boxer.Args.VerbArgs
{
    public class HelpArg : IArg
    {
        public HelpArg()
        {
            LongName = "Help";
        }

        public string ShortName { get; }

        public string LongName { get; }

        public string Help { get; }
    }
}
