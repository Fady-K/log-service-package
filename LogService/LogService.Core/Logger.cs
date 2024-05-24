using LogService.Core.LogStrategies;
using LogService.Formatting.Core;

namespace LogService.Core
{
	public class Logger : AbstractLogger
	{
        public Logger(ILogStrategy logStartegy, AbstractFormatter formatter) : base(logStartegy, formatter)
        {
            
        }
        /////////////////////////////////////////////// Helper methods ////////////////////////////
        ///
    }
}
