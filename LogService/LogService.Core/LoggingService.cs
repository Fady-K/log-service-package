using System;
using System.IO;
using LogService.Core.LogStrategies;
using LogService.FileHandling;
using LogService.Formatting.Core;
using LogService.LogService.LogService.Core.LogFilePathLoadingStrategies;

namespace LogService.Core
{
	/// <summary>
	/// The LoggingService class.
	/// This class is responsible for logging messages. It uses an AbstractLogger for logging and an AbstractFileHandler for file handling.
	/// </summary>
	/// <remarks>
	/// This class follows the Singleton design pattern to ensure that only one instance of LoggingService exists in the application.
	/// </remarks>
	/// <seealso cref="AbstractLogger"/>
	/// <seealso cref="AbstractFileHandler"/>
	public class LoggingService
	{
		/* Static attribute (related to class only) */

		/// <summary>
		/// The single instance of the LoggingService class.
		/// </summary>
		private static LoggingService _instance;


		/* Instance attributes */

		/// <summary>
		/// The strategy used for loading the log file path.
		/// </summary>
		protected AbstractLogFilePathLoadingStrategy _logFilePathLoadingStrategy;

		/// <summary>
		/// The logger used by this service.
		/// </summary>
		protected AbstractLogger _logger;

		/// <summary>
		/// The file handler used by this service.
		/// </summary>
		protected AbstractFileHandler _fileHandler;


		/* Constructors */

		/// <summary>
		/// Default constructor.
		/// Initializes a new instance of the LoggingService class and sets up the logger and file handler.
		/// </summary>
		public LoggingService()
		{
			// Init instance attributes 
			Initialize();
		}

		/// <summary>
		/// Paramerized constructor.
		/// Initializes a new instance of the LoggingService class and sets up the logger and file handler.
		/// </summary>
		public LoggingService(AbstractLogFilePathLoadingStrategy logFilePathLoadingStrategy)
		{
			// Init instance attributes 
			Initialize(logFilePathLoadingStrategy);
		}


		/* Setters and getters */

		/// <summary>
		/// Gets the path of the log file.
		/// </summary>
		public string LogFilePath { get => _logFilePathLoadingStrategy.LogFilePath; }

		/// <summary>
		/// Gets the default path of the log file.
		/// </summary>
		public string DefaultLogFilePath { get => _logFilePathLoadingStrategy.DefaultLogFilePath; }


		/// <summary>
		/// Get and Sets the loading mechansism for log file path.
		/// </summary>
		public AbstractLogFilePathLoadingStrategy LogFilePathLoadingStrategy { get => _logFilePathLoadingStrategy; set => _logFilePathLoadingStrategy = value; }

		/// <summary>
		/// Gets or sets the logger used by this service.
		/// </summary>
		public AbstractLogger Logger { get => _logger; set => _logger = value; }

		/// <summary>
		/// Gets the file handler used by this service.
		/// </summary>
		public AbstractFileHandler FileHandler { get => _fileHandler; }


		/* Instance methods */
		/// <summary>
		/// Logs a series of objects.
		/// </summary>
		/// <param name="messageComponents">The objects to log.</param>
		/// <exception cref="Exception">Throws an exception if an error occurs while logging the message.</exception>
		public void Log(params object[] messageComponents)
		{
			try
			{
				// Log the message
				_logger.Log(messageComponents);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}


		//////////////////////////////////////// Static methods /////////////////////////////////

		/// <summary>
		/// Gets the single instance of the LoggingService class.
		/// </summary>
		/// <returns>The single instance of the LoggingService class.</returns>
		public static LoggingService GetInstance()
		{
			if (_instance is null)
			{
				// Init it
				_instance = new LoggingService();
			}

			// Return the instance 
			return _instance;
		}


		/// <summary>
		/// Initializes the single instance of the LoggingService class with a specified log file path loading strategy.
		/// </summary>
		/// <param name="logFilePathLoadingStrategy">The log file path loading strategy to be used by the LoggingService instance.</param>
		public static void InitInstanceWithConfig(AbstractLogFilePathLoadingStrategy logFilePathLoadingStrategy)
		{
			// Init it
			_instance = new LoggingService(logFilePathLoadingStrategy);
		}


		//////////////////////////////////////// Helper methods ////////////////////////////////

		/// <summary>
		/// Initializes the LoggingService instance.
		/// </summary>
		/// <exception cref="Exception">Throws an exception if an error occurs while initializing the instance.</exception>
		protected void Initialize(AbstractLogFilePathLoadingStrategy logFilePathLoadingStrategy =null)
		{
			try
			{
				// Init logFilePathLoadingStrateg
				_logFilePathLoadingStrategy = logFilePathLoadingStrategy ?? new LoadLogFilePathFromXMLAppConfig();

				// Init log file handler with paths 
				_fileHandler = new LogFileHandler(LogFilePath, DefaultLogFilePath);

				// Init Logger with valid path
				_logger = new Logger(new InstantMessageLoggingStrategy(_fileHandler.FileValidPath), new LogMessageFormatter());
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
