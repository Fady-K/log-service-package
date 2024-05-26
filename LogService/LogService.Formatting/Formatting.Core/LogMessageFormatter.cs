using LogService.Formatting.FormattingStrategies;

namespace LogService.Formatting.Core
{
	/// <summary>
	/// The LogMessageFormatter class is responsible for formatting log messages.
	/// It both extends and implements the AbstractFormatter class.
	/// </summary>
	public class LogMessageFormatter : AbstractFormatter
	{
		/// <summary>
		/// Default constructor for the LogMessageFormatter class.
		/// It initializes the _formateStrategy field with a new instance of FormatingLogMessageStrategy.
		/// </summary>
		public LogMessageFormatter()
		{
			_formateStrategy = new FormatingLogMessageStrategy();
		}
	}
}
