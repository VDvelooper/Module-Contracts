using ModuleContracts.ServiceContracts;

namespace ModuleContracts
{
    public class Contracts
    {
        public IConsoleViewContract ConsoleViewContract { get; private set; }
        public ICommandExecuterContract CommandExecuterContract { get; private set; }
        public IConfigManagerContract ConfigManagerContract { get; private set; }
        public ICommandParserContract CommandParserContract { get; private set; }

        public Contracts(IConsoleViewContract consoleViewContract, 
            ICommandExecuterContract commandExecuterContract,
            IConfigManagerContract configManagerContract,
            ICommandParserContract commandParserContract)
        {
            ConsoleViewContract = consoleViewContract;
            CommandExecuterContract = commandExecuterContract;
            ConfigManagerContract = configManagerContract;
            CommandParserContract = commandParserContract;
        }
    }
}
