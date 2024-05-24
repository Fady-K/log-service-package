using LogService.Formatting.FormattingStrategies;

namespace LogService.Formatting.Core
{
	public class LogMessageFormatter : AbstractFormatter
	{
        public LogMessageFormatter()
        {
            _formateStrategy = new FormatingLogMessageStrategy();
        }
    }
}
