using ModuleContracts.Abstractions;
using ModuleContracts.Operations;

namespace ModuleContracts.ServiceContracts
{
    public interface ICommandParserContract
    {
        ArgumentOperation? Parse(string? rawInput, ModuleBase sender);
    }
}
