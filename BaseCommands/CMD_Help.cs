using ModuleContracts.Feedback;

namespace ModuleContracts.Abstractions
{
    internal class CMD_Help : ICommand
    {
        public string Syntax { get; }
        public int RequiredArgCount { get; }
        public int OptionalArgCount { get; }
        public string Description { get; }
        public ModuleBase ParentModule { get; }

        public CMD_Help(string syntax, int requiredArgCount, int optionalArgCount, string description, ModuleBase parentModule)
        {
            Syntax = syntax;
            RequiredArgCount = requiredArgCount;
            OptionalArgCount = optionalArgCount;
            Description = description;
            ParentModule = parentModule;
        }


        public IFeedback? Run(UserInput userInput)
        {
            ParentModule.BaseCommands.ForEach(command => ParentModule.Contracts.ConsoleViewContract.Message($"{command.Syntax} - {command.Description}"));

            return null;
        }
    }
}
