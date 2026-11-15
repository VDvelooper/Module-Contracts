using ModuleContracts.Operations;

namespace ModuleContracts.ServiceContracts
{
    public interface ICommandExecuterContract
    {
        void ExecuteCommand(ArgumentOperation? userInput);
    }
}
