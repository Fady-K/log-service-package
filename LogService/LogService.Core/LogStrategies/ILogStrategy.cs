namespace LogService.Core.LogStrategies
{
	/// <summary>
	/// The ILogStartegy Interface that provides an interface for different startegies.
	/// <remarks>This ILogStrategy is implemented by differnet concrete startegies</remarks>
	/// <seealso cref="AccumulativeMessageBasedThresholdLoggingStrategy"/>
	/// <seealso cref="InstantMessageLoggingStrategy"/>
	/// </summary>
	public interface ILogStrategy
	{
		/// <summary>
		/// Takes a message to log it.
		/// </summary>
		/// <param name="message">Message that is about to get logged.</param>
		void Log(string message);

		/// <summary>
		/// Property for validLogFilePath.
		/// </summary>
		string ValidLogFilePath { get; set; }
	}
}
