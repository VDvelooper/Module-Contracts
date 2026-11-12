using ModuleContracts.Feedback.Error;
using ModuleContracts.Feedback;

namespace ModuleContracts.Abstractions
{
    public class CMD_Exit : ICommand
    {
        public string Syntax { get; }
        public int RequiredArgCount { get; }
        public int OptionalArgCount { get; }
        public string Description { get; }
        public ModuleBase ParentModule { get; }

        public CMD_Exit(string syntax, int requiredArgCount, int optionalArgCount, string description, ModuleBase parentModule)
        {
            Syntax = syntax;
            RequiredArgCount = requiredArgCount;
            OptionalArgCount = optionalArgCount;
            Description = description;
            ParentModule = parentModule;
        }


        public IFeedback? Run(UserInput userInput)
        {
            if (ParentModule == null) return new NotFound("The sender module is null.");
            if (!ParentModule.IsProgram) return null;
            if (!ParentModule.IsProgramRunning) return null;

            ParentModule.IsProgramRunning = false;

            return null;
        }
    }
}
