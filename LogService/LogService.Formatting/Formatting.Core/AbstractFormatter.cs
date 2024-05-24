using LogService.Formatting.FormattingStrategies;
using System;

namespace LogService.Formatting.Core
{
	public abstract class AbstractFormatter
	{
		/* Fields */
		protected IFormateStrategy _formateStrategy;


        /* Constructors */
        public AbstractFormatter()
        {
            _formateStrategy = new DefaultFormattingStrategy();
        }

        public AbstractFormatter(IFormateStrategy formateStrategy)
        {
            _formateStrategy = formateStrategy;
        }


        /* Setters and getters */
        public IFormateStrategy FormateStrategy { get => _formateStrategy; set => _formateStrategy = value; }
        

        /* Instance methods */
        public object Formate(params object[] param)
        {
            try
            {
                return _formateStrategy.Formate(param);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
