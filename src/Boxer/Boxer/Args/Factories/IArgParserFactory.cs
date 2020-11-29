namespace Boxer.Args.Factories
{
    public interface IArgParserFactory
    {
        IArgParser this[string key] { get; }
    }
}
