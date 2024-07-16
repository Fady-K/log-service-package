namespace LogService.LogService.LogService.Core.LogFilePathLoadingStrategies
{
	/// <summary>
	/// The AbstractLogFilePathLoadingStrategy class.
	/// This abstract class provides the strategy for loading log file paths.
	/// </summary>
	/// <remarks>
	/// This class follows the Strategy design pattern to allow different mechanisms for loading log file paths to be used interchangeably.
	/// </remarks>
	/// <seealso cref="LoadLogFilePathFromXMLAppConfig"/>
	public abstract class AbstractLogFilePathLoadingStrategy
	{
		/* Instance Attributes */

		/// <summary>
		/// The path of the log file.
		/// </summary>
		protected string __logFilePath;

		/// <summary>
		/// The default path of the log file.
		/// </summary>
		protected string __defaultLogFilePath;


		/* Constructors */

		/// <summary>
		/// Initializes a new instance of the AbstractLogFilePathLoadingStrategy class.
		/// </summary>
		public AbstractLogFilePathLoadingStrategy()
		{
			// Init instance attributes 
			__logFilePath = string.Empty;
			__defaultLogFilePath = string.Empty;
		}


		/* Setters and getters (properties) */

		/// <summary>
		/// Gets the path of the log file.
		/// </summary>
		public string LogFilePath => __logFilePath;

		/// <summary>
		/// Gets the default path of the log file.
		/// </summary>
		public string DefaultLogFilePath => __defaultLogFilePath;


		/* Instance Methods */

		/// <summary>
		/// Loads the path of the log file.
		/// </summary>
		/// <param name="configFile">The configuration file.</param>
		/// <param name="key">The key to retrieve the log file path.</param>
		protected abstract void LoadLogFilePath(string configFile, string key);

		/// <summary>
		/// Loads the default path of the log file.
		/// </summary>
		/// <param name="configFile">The configuration file.</param>
		/// <param name="key">The key to retrieve the default log file path.</param>
		protected abstract void LoadDefaultLogFilePath(string configFile, string key);
	}
}
