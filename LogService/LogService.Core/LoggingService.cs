using System;
using System.Configuration;
using LogService.Core.LogStrategies;
using LogService.Enums;
using LogService.FileHandling;
using LogService.Formatting.Core;

namespace LogService.Core
{
	/// <summary>
	/// This class is a singleton class
	/// </summary>
	public class LoggingService
	{
        /* Static attribute (related to class only) */
        private static LoggingService _instance;


		/* Instance attributes */
		protected string _logFilePath;
		protected string _defaultLogFilePath;
        protected AbstractLogger _logger;
        protected AbstractFileHandler _fileHandler;


        /* Constructors */
        public LoggingService()
        {
            // Init instance attributes 
            Initialize();
        }


        /* Setters and getters */
        public string LogFilePath { get => _logFilePath; }
        public string DefaultLogFilePath { get => _defaultLogFilePath; }
        public AbstractLogger Logger { get => _logger; set => _logger = value; }
        public AbstractFileHandler FileHandler { get => _fileHandler; }


        /* Instance methods */
        public void Log(string message, MessageType type)
        {
            try
            {
				// Log the message
				_logger.Log(message, type);
			}
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
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
		///
		public static LoggingService GetIntance()
        {
            if (_instance is null)
            {
                // Init it
                _instance = new LoggingService();
            }

            // Return the instance 
            return _instance;
        }


        //////////////////////////////////////// Helper methods ////////////////////////////////
        //
        protected void Initialize()
        {
            try
            {
				// Load pathes from app.config
				_logFilePath = ConfigurationManager.AppSettings["log_file_path"];
				_defaultLogFilePath = ConfigurationManager.AppSettings["log_file_default_path"];

				// Init log file handler with pathes 
				_fileHandler = new LogFileHandler(_logFilePath, _defaultLogFilePath);

				// Init Logger with valid path
				_logger = new Logger(new InstanteMessageLoggingLogStrategy(_fileHandler.FileValidPath), new LogMessageFormatter());
                
			}
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
