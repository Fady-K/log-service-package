using System;
using System.Configuration;
using System.IO;

namespace LogService.LogService.LogService.Core.LogFilePathLoadingStrategies
{
	/// <summary>
	/// The LoadLogFilePathFromXMLAppConfig class.
	/// This class is responsible for loading log file paths from an XML configuration file (e.g., app.config).
	/// </summary>
	/// <remarks>
	/// This class extends the AbstractLogFilePathLoadingStrategy class and provides concrete implementations for loading log file paths and default log file paths.
	/// </remarks>
	/// <seealso cref="AbstractLogFilePathLoadingStrategy"/>
	public class LoadLogFilePathFromXMLAppConfig : AbstractLogFilePathLoadingStrategy
	{
		/* Constructors */

		/// <summary>
		/// Initializes a new instance of the LoadLogFilePathFromXMLAppConfig class.
		/// Combines the XML config file path and passes it to the loading method.
		/// </summary>
		/// <param name="configFileName">The name of the configuration file. Default is "app.config".</param>
		/// <param name="configFilePath">The path to the configuration file. Default is the current directory.</param>
		/// <param name="pathKey">The key for the log file path in the configuration file. Default is "log_file_path".</param>
		/// <param name="defaultPathKey">The key for the default log file path in the configuration file. Default is "log_file_default_path".</param>
		public LoadLogFilePathFromXMLAppConfig(string configFileName = "app.config", string configFilePath = ".", string pathKey = "log_file_path", string defaultPathKey = "log_file_default_path")
		{
			// Combine xml config file path and path it to the loading method.
			string fullConfigFilePath = Path.Combine(configFilePath, configFileName);

			// Load log file path
			LoadLogFilePath(fullConfigFilePath, pathKey);

			// Load the default log file path.
			LoadDefaultLogFilePath(fullConfigFilePath, defaultPathKey);
		}


		/* Method to Load Log File Path from Config File */

		/// <summary>
		/// Retrieves the configuration from the specified configuration file.
		/// </summary>
		/// <param name="configFilePath">The path to the configuration file.</param>
		/// <returns>The configuration object loaded from the specified file.</returns>
		protected System.Configuration.Configuration GetConfiguration(string configFilePath)
		{
			// Create a configuration file map
			var configFileMap = new ExeConfigurationFileMap
			{
				ExeConfigFilename = configFilePath
			};

			// Load the configuration from the specified file
			return ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
		}

		/// <summary>
		/// Loads the log file path from the specified configuration file.
		/// </summary>
		/// <param name="configFilePath">The path to the configuration file.</param>
		/// <param name="key">The key to retrieve the log file path.</param>
		protected override void LoadLogFilePath(string configFilePath, string key)
		{
			// Retrieve the log file path from appSettings
			string path = GetConfiguration(configFilePath).AppSettings.Settings[key]?.Value ?? "./Log/Log.txt";

			// Resolve any Environment variables in the path.
			__logFilePath = Environment.ExpandEnvironmentVariables(path);
		}

		/// <summary>
		/// Loads the default log file path from the specified configuration file.
		/// </summary>
		/// <param name="configFilePath">The path to the configuration file.</param>
		/// <param name="key">The key to retrieve the default log file path.</param>
		protected override void LoadDefaultLogFilePath(string configFilePath, string key)
		{
			// Retrieve the log file path from appSettings
			string path = GetConfiguration(configFilePath).AppSettings.Settings[key]?.Value ?? "./Log/Log.txt";

			// Resolve any Environment variables in the path.
			__defaultLogFilePath = Environment.ExpandEnvironmentVariables(path);
		}
	}
}
