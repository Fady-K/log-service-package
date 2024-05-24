using System;
using System.Collections.Generic;


namespace LogService.Core.LogStrategies
{
	/// <summary>
	/// This strategy takes a message then addes it to the list of logs, the strategy will append these messages at once when the program is closing. (This strategy is at risk of being aborted incase the program closed in abnormal way or was distrubted by the sytem)
	/// </summary>
	public class AccumulativeMessageLoggingLogStrategy: ILogStrategy
	{
		/* Instance attributes */
		protected string _validLogFilePath;
		protected List<string> _logs;


        /* Constructors */
        public AccumulativeMessageLoggingLogStrategy(string validLogFilePath)
        {
			// Init local attributes 
			ValidLogFilePath = validLogFilePath;
			Logs = new List<string>();
        }


		/* Setters and getters */
		public string ValidLogFilePath { get => _validLogFilePath; set => _validLogFilePath = value; }
		public List<string> Logs { get => _logs;  protected set => _logs = value; }


		/* Instance methods */
		public void Log(string message)
		{
			throw new NotImplementedException();
		}
	}
}
