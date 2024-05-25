namespace LogService.Core.LogStrategies
{
	/// <summary>
	/// The ILogStartegy Interface that provides an interface for different startegies.
	/// <remarks>This ILogStrategy is implemented by differnet concrete startegies</remarks>
	/// <seealso cref="AccumulativeMessageLoggingStrategy"/>
	/// <seealso cref="DefaultLogStrategy"/>
	/// <seealso cref="InstanteMessageLoggingStrategy"/>
	/// </summary>
	public interface ILogStrategy
	{
		void Log(string message);
		string ValidLogFilePath { get; set; }
	}
}
