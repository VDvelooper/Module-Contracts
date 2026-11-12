using ModuleContracts.Abstractions;
using ModuleContracts.Feedback;

namespace ModuleContracts.ServiceContracts
{
    public interface IConsoleViewContract
    {
        void PresentFeedback(IFeedback feedback);
        void Message(string? message = null, bool newLine = true, ConsoleOutputStyle? outputStyle = null);
        void Debug(string message, bool newLine = true);
        void Warn(string message, bool newLine = true);
        void Error(string message, bool newLine = true);
        void FatalError(string message, bool newLine = true);
        string ReadUserInput(string senderName);
    }
}
