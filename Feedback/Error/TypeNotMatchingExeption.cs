using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModuleContracts.Feedback.Error
{
    public class TypeNotMatchingExeption : IFeedback
    {
        public FeedbackType ResultType { get; } = FeedbackType.Error;
        public string FeedbackID { get; } = "Error.TypeNotMatchingExeption";
        public CallerInformation Details { get; private set; }
        public string? Description { get; }
        public bool Silent { get; } = false;
        public string? ConsoleOutputOverride { get; }
        public ModuleContracts.Abstractions.ConsoleOutputStyle ConsoleOutputStyle { get; private set; } = new(ConsoleColor.DarkRed, ConsoleColor.Black);


        public TypeNotMatchingExeption(string? description = null,
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
