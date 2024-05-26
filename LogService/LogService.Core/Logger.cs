using LogService.Core.LogStrategies;
using LogService.Formatting.Core;

namespace LogService.Core
{
	/// <summary>
	/// The Logger class provides logging functionality and is responsible for logging messages.
	/// It inherits from the AbstractLogger class.
	/// </summary>
	public class Logger : AbstractLogger
	{
		/// <summary>
		/// Initializes a new instance of the Logger class with the specified log strategy and formatter.
		/// </summary>
		/// <param name="logStartegy">The log strategy to be used by this Logger instance.</param>
		/// <param name="formatter">The formatter to be used by this Logger instance.</param>
		public Logger(ILogStrategy logStartegy, AbstractFormatter formatter) : base(logStartegy, formatter)
		{

		}
		// Implementation of helper methods goes here...
	}
}
