using ModuleContracts.Abstractions;

namespace ModuleContracts.Feedback
{
    public interface IFeedback
    {
        public FeedbackType ResultType { get; }
        public string FeedbackID { get; }
        public CallerInformation Details { get; }
        public string? Description { get; }
        public bool Silent { get; }
        public string? ConsoleOutputOverride { get; }
        public ConsoleOutputStyle ConsoleOutputStyle { get; }
    }
}
