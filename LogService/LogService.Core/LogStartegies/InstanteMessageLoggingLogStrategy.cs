using System;
using System.IO;

namespace LogService.Core.LogStrategies
{
	/// <summary>
	/// This strategy takes and message then logs it immediatly (it opens the file and append it per each message) Heavy IO Operation.
	/// </summary>
	public class InstanteMessageLoggingLogStrategy: ILogStrategy
	{
		/* Instance attributes */
		protected string _validLogFilePath;


        /* Constructors */
        public InstanteMessageLoggingLogStrategy(string validLogFilePath)
        {
			// Init local attributes
			ValidLogFilePath = validLogFilePath;
        }


		/* Setters and getters */
		public string ValidLogFilePath { get => _validLogFilePath; set => _validLogFilePath = value; }


		/* Instance methos */
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
