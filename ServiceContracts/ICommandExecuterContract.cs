using ModuleContracts.Abstractions;

namespace ModuleContracts.ServiceContracts
{
    public interface ICommandExecuterContract
    {
        void ExecuteCommand(UserInput? userInput);
    }
}
