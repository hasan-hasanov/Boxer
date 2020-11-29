using System.Threading.Tasks;

namespace Boxer.Parser
{
    public interface ICommandLineArgsParser
    {
        Task Parse(string[] args);
    }
}
