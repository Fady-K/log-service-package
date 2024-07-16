namespace LogService.LogService.LogService.Core.LogFilePathLoadingStrategies
{
	public abstract class AbstractLogFilePathLoadingStrategy
	{
		/* Instance Attributes */
		protected string __logFilePath;
		protected string __defaultLogFilePath;

		/* Constructors */
		public AbstractLogFilePathLoadingStrategy()
		{
			// Init Instance attributese 
			__logFilePath = string.Empty;
			__defaultLogFilePath = string.Empty;
		}


		/* Setters and getters (properties) */
		public string LogFilePath => __logFilePath;
		public string DefaultLogFilePath => __defaultLogFilePath;

		/* Instance Methods */
		protected abstract void LoadLogFilePath(string configFile, string key);
		protected abstract void LoadDefaultLogFilePath(string configFile, string key);
	}
}
