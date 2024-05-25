using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LogService.Core.LogStrategies
{
	/// <summary>
	/// The AccumulativeMessageLoggingStrategy class.
	/// <remarks>This class implements the ILogStrategy interface and provides a log startegy that logs the accumulated message when the system is closed.</remarks>
	/// <seealso cref="ILogStrategy"/>
	/// </summary>
	public class AccumulativeMessageBasedThresholdLoggingStrategy: ILogStrategy
	{
		/* Instance attributes */
		protected string _validLogFilePath;
		protected List<string> _logs;
		protected int _flushingThreshold;


        /* Constructors */
        public AccumulativeMessageBasedThresholdLoggingStrategy(string validLogFilePath, int messagesCountThreshold=10)
        {
			// Init local attributes 
			_validLogFilePath = validLogFilePath;
			_logs = new List<string>();
			FlushingThreshold = messagesCountThreshold;

			// Subscribe the CurrentDomain_ProcessExit to the appdomain.currentDomain
			AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
        }


		/* Setters and getters */

		/// <summary>
		/// The setter and getter of ValidLogFilePath field.
		/// </summary>
		public string ValidLogFilePath { get => _validLogFilePath; set => _validLogFilePath = value; }

		/// <summary>
		/// Setter and getter of the flushing threshold.
		/// </summary>
		/// <exception cref="Exception">Throws an exception if the threshold to be set, is 0 or less.</exception>
		public int FlushingThreshold { get => _flushingThreshold; set { if (value > 0) { _flushingThreshold = value; } else { throw new ArgumentException("invalid threshold: can't be 0 or less"); } } }

		/// <summary>
		/// Setter and getters of accumulated logs;
		/// </summary>
		public List<string> Logs { get => _logs; protected set => _logs = value; }


		/* Instance methods */
		/// <summary>
		/// Takes and message and then adds them to accumulative logs.
		/// </summary>
		/// <param name="message">Log message that will added to accumulated logs.</param>
		/// <seealso cref="Logs"/>
		public void Log(string message)
		{
			// If logs has reached the flushing threshold, flush it before adding to it
			if (Logs.Count.Equals(_flushingThreshold))
			{
				// Flush
				FlushToLogFile();

			}

			// Logs the message by adding it to message
			_logs.Add(message);
		}


		/// <summary>
		/// Handles the ProcessExit event of the current application domain. This method is called when the application is about to close.
		/// It writes all the accumulated log messages stored in memory to the log file.
		/// </summary>
		/// <param name="sender">The source of the event. In this case, it's the current application domain.</param>
		/// <param name="e">An EventArgs that contains no event data.</param>
		protected void CurrentDomain_ProcessExit(object sender, EventArgs e)
		{
			// Log messages to log file if not empty
			if (_logs.Count != 0)
			{
				FlushToLogFile();
			}
		}


		/// <summary>
		/// Writes all accumulated log messages to the log file.
		/// </summary>
		/// <remarks>
		/// This method is called when the number of log messages reaches the flushing threshold or when the application is about to close.
		/// It writes all the accumulated log messages stored in memory to the log file.
		/// </remarks>
		/// <exception cref="Exception">Throws an exception if an error occurs while writing to the log file.</exception>
		protected void FlushToLogFile()
		{
			try
			{
				// Log all stored messages in the logs field.
				StringBuilder sb = new StringBuilder();

				foreach (string log in _logs)
				{
					sb.AppendLine(log);
				}

				// Write all of these lines to the 
				File.AppendAllText(_validLogFilePath, sb.ToString());

				// Clear the logs to complete the flushing process.
				_logs.Clear();

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
