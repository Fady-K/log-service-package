namespace LogService.Core.LogStrategies
{
	public interface ILogStrategy
	{
		void Log(string message);
		string ValidLogFilePath { get; set; }
	}
}
