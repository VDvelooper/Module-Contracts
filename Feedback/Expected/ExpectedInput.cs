using System.Runtime.CompilerServices;

namespace ModuleContracts.Feedback.Expected
{
    public class ExpectedInput : IFeedback
    {
        public FeedbackType ResultType { get; } = FeedbackType.Expected;
        public string FeedbackID { get; } = "Expected.ExpectedInput";
        public CallerInformation Details { get; private set; } 
        public string? Description { get; }
        public bool Silent { get; } = false;
        public string? ConsoleOutputOverride { get; }
        public ModuleContracts.Abstractions.ConsoleOutputStyle ConsoleOutputStyle { get; private set; } = new();

        
        public ExpectedInput(string? description = null,
            string? consoleOutputOverride = null,
            bool silent = false,
            [CallerMemberName] string sourceName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = -1)
        {
            Description = description;
            ConsoleOutputOverride = consoleOutputOverride;
            Silent = silent;

            Details = new CallerInformation();
            Details.SourceName = sourceName;
            Details.SourceFilePath = sourceFilePath;
            Details.SourceLineNumber = sourceLineNumber;
        }
    }
}
