using ModuleContracts.Abstractions;

namespace ModuleContracts.Operations
{
    public class ArgumentOperation
    {
        public string Raw;
        public ICommand Command;

        public List<string> RequiredArgs;
        public int RequiredArgsCount;

        public List<string> OptionalArgs;
        public int OptionalArgsCount;

        public bool ContainsRequiredArgs 
        { 
            get {
                if (RequiredArgsCount > 0)
                    return RequiredArgs.Count > 0;
                else return true;
            } 
        }
        public bool ContainsOptionalArgs
        {
            get {
                if (RequiredArgsCount > 0)
                    return OptionalArgs.Count > 0;
                else return true;
            }
        }
        
        public ArgumentOperation(ICommand command, List<string> requiredArgs, int requiredArgsCount, List<string> optionalArgs, int optionalArgsCount, string raw) 
        {
            Raw = raw;
            Command = command;
            RequiredArgs = requiredArgs;
            RequiredArgsCount = requiredArgsCount;
            OptionalArgs = optionalArgs;
            OptionalArgsCount = optionalArgsCount;
        }
    }
}
