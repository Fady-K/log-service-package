using System;


namespace LogService.Core.LogStrategies
{
	public class DefaultLogStrategy : ILogStrategy
	{
		public string ValidLogFilePath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public void Log(string message)
		{
			throw new NotImplementedException();
		}
	}
}
