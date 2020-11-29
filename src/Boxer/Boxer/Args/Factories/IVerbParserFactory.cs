namespace Boxer.Args.Factories
{
    public interface IVerbParserFactory
    {
        IVerbParser this[string key] { get; }
    }
}
