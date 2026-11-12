using ModuleContracts.Feedback.Error;
using ModuleContracts.Feedback;

namespace ModuleContracts.Abstractions
{
    internal class CMD_ModuleExecute : ICommand
    {
        public string Syntax { get; }
        public int RequiredArgCount { get; }
        public int OptionalArgCount { get; }
        public string Description { get; }

        public ModuleBase ParentModule { get; }

        public CMD_ModuleExecute(string syntax, int requiredArgCount, int optionalArgCount, string description, ModuleBase parentModule)
        {
            Syntax = syntax;
            RequiredArgCount = requiredArgCount;
            OptionalArgCount = optionalArgCount;
            Description = description;
            ParentModule = parentModule;
        }

        /// <summary>
        /// Calls the parent Module's entry point.
        /// </summary>
        public IFeedback? Run(UserInput userInput)
        {
            if (userInput.OptionalArgs.Count > 0)
            {
                ICommand? subCommand;

                /*CommandRegistry.TryGetModuleCommand(userInput.OptionalArgs[0], out subCommand);

                if (subCommand != null)
                    return subCommand.Execute(userInput);*/ // zzz
            }

            return ParentModule.ModuleExecute(userInput);
        }
    }
}