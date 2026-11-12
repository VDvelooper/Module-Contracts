using System.Runtime.CompilerServices;

namespace ModuleContracts.Feedback.Error
{
    public class MissingRequiredArgument : IFeedback
    {
        public FeedbackType ResultType { get; } = FeedbackType.Error;
        public string FeedbackID { get; } = "Error.MissingRequiredArgument";
        public CallerInformation Details { get; private set; }
        public string? Description { get; }
        public bool Silent { get; } = false;
        public string? ConsoleOutputOverride { get; }
        public ModuleContracts.Abstractions.ConsoleOutputStyle ConsoleOutputStyle { get; private set; } = new(ConsoleColor.DarkRed, ConsoleColor.Black);

        public MissingRequiredArgument(string? description = null,
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