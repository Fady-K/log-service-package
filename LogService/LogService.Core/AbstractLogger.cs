using LogService.Core.LogStrategies;
using LogService.Formatting.Core;

namespace LogService.Core
{
	/// <summary>
	/// The AbstractLogger class.
	/// This is an abstract base class for all logger classes in the application.
	/// It provides common functionality for logging messages, including formatting and flushing logs.
	/// </summary>
	/// <remarks>
	/// This class uses the Strategy design pattern to allow different logging and formatting behaviors to be used interchangeably.
	/// </remarks>
	/// <seealso cref="ILogStrategy"/>
	/// <seealso cref="AbstractFormatter"/>
	public abstract class AbstractLogger
	{
		/* Fields */

		/// <summary>
		/// The log strategy used by this logger.
		/// This determines how log messages are handled (e.g., how and when they are written to a log file or other storage).
		/// </summary>
		/// <seealso cref="ILogStrategy"/>
		protected ILogStrategy _logStrategy;

		/// <summary>
		/// The formatter used by this logger.
		/// This determines how log messages are formatted before they are logged.
		/// </summary>
		/// <seealso cref="AbstractFormatter"/>
		protected AbstractFormatter _formatter;


		/* Constructors */

		/// <summary>
		/// Default constructor.
		/// Initializes a new instance of the AbstractLogger class with a default log message formatter.
		/// </summary>
		public AbstractLogger()
		{
			_formatter = new LogMessageFormatter();
			//_logStrategy = new DefaultLogStrategy();
		}

		/// <summary>
		/// Constructor with parameters.
		/// Initializes a new instance of the AbstractLogger class with the specified log strategy and formatter.
		/// </summary>
		/// <param name="logStrategy">The log strategy to use.</param>
		/// <param name="formatter">The formatter to use.</param>
		public AbstractLogger(ILogStrategy logStrategy, AbstractFormatter formatter)
		{
			_formatter = formatter;
			_logStrategy = logStrategy;
		}


		/* Setters and getters */

		/// <summary>
		/// Gets or sets the log strategy used by this logger.
		/// </summary>
		public ILogStrategy LogStrategy { get => _logStrategy; set => _logStrategy = value; }

		/// <summary>
		/// Gets or sets the formatter used by this logger.
		/// </summary>
		public AbstractFormatter Formatter { get => _formatter; set => _formatter = value; }


		/* Virtual Methods */
		/// <summary>
		/// Logs a series of objects.
		/// The objects are formatted into a single message and then logged using the current log strategy.
		/// </summary>
		/// <param name="logContent">The objects to log.</param>
		/// <seealso cref="ILogStrategy.Log(string)"/>
		/// <seealso cref="AbstractFormatter.Formate(object[])"/>
		public virtual void Log(params object[] logContent)
		{
			// Formate log content into message
			string message = Formatter.Formate(logContent).ToString();

			// Log the formated message
			LogStrategy.Log(message);
		}
	}
}
