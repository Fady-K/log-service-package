using LogService.Enums;
using LogService.Core.LogStrategies;
using LogService.Formatting.Core;

namespace LogService.Core
{
	public abstract class AbstractLogger
	{
		/* Fields */
		protected ILogStrategy _logStrategy;
		protected AbstractFormatter _formatter;


		/* Constructors */
		public AbstractLogger()
		{
			_formatter = new LogMessageFormatter();
			_logStrategy = new DefaultLogStrategy();
		}
		
		public AbstractLogger(ILogStrategy logStrategy, AbstractFormatter formatter)
        {
			_formatter = formatter;
            _logStrategy = logStrategy;
        }


        /* Setters and getters */
		public ILogStrategy LogStrategy { get => _logStrategy; set => _logStrategy = value; }
		public AbstractFormatter Formatter { get => _formatter; set => _formatter = value; }


		/* Abstract Methods */
		public virtual void Log(string message, MessageType type)
		{
			// Prepare the message to be logged
			message = Formatter.Formate(message, type).ToString();

			// Log the message
			LogStrategy.Log(message);
		}

		public virtual void Log(params object[] logContent)
		{
			// Formate log content into message
			string message = Formatter.Formate(logContent).ToString();

			// Log the formated message
			LogStrategy.Log(message);
		}
	}
}
