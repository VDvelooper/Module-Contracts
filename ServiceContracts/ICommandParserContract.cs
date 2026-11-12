using ModuleContracts.Abstractions;

namespace ModuleContracts.ServiceContracts
{
    public interface ICommandParserContract
    {
        UserInput? Parse(string? rawInput, ModuleBase sender);
    }
}
