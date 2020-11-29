namespace Boxer.CommandLineArgs.Args
{
    public interface IArg
    {
        string ShortName { get; }

        string LongName { get; }

        string Help { get; }
    }
}
