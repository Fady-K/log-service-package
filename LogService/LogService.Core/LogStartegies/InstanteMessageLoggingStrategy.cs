using System;
using System.IO;

namespace LogService.Core.LogStrategies
{
	/// <summary>
	/// The InstantMessageLoggingStartegy.
	/// <remarks>This startegy implements the ILogStrategy interface, and takes log message (log implemeneted) and then log it instantly.</remarks>
	/// <seealso cref="ILogStrategy"/>
	/// <seealso cref="Log(string)"/>
	/// </summary>
	public class InstanteMessageLoggingStrategy: ILogStrategy
	{
		/* Instance attributes */

		/// <summary>
		/// The valid log file path
		/// </summary>
		protected string _validLogFilePath;


        /* Constructors */
		/// <summary>
		/// Parametrized constructor of InstantMessageLoggingStrategy.
		/// </summary>
		/// <remarks>Takes validLogFilePath</remarks>
		/// <param name="validLogFilePath">Valid path of the log file</param>
        public InstanteMessageLoggingStrategy(string validLogFilePath)
        {
			// Init local attributes
			ValidLogFilePath = validLogFilePath;
        }


		/* Setters and getters */
		/// <summary>
		/// Property for validLogFilePath.
		/// </summary>
		public string ValidLogFilePath { get => _validLogFilePath; set => _validLogFilePath = value; }


		/* Instance methos */

		/// <summary>
		/// Takes a message to log it.
		/// </summary>
		/// <param name="message">Message that is about to get logged.</param>
		/// <exception cref="System.Exception"></exception>
		public void Log(string message)
		{
			try
			{
				// Log using stream writter
				using (StreamWriter sw = File.AppendText(_validLogFilePath))
				{
					// write message
					sw.WriteLine(message);
				}
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}

		}
	}
}
