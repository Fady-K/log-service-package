namespace LogService.Formatting.FormattingStrategies
{
	public class DefaultFormattingStrategy : IFormateStrategy
	{
		/* Insatnce attributes */
		protected string _sep;

        /* Constructors */
        public DefaultFormattingStrategy()
        {
			_sep = "-";
        }

        /* Setters and getters */
		public string Sep { get => _sep; set => _sep = value; }


		/* Instance methods */
        public object Formate(params object[] param)
		{
			// Just append all params into string (join them) and trim the output, finally return it.
			string result = "";

			// Iterate over them and join then finally return result
			foreach(var item in param)
			{
				result += (item.ToString() + _sep);
			}

			// Return result trimmed
			if (char.TryParse(_sep, out char sepAsChar))
			{
				return result.TrimEnd(sepAsChar);
			}
			else
			{
				return result.Trim(_sep.ToCharArray());
			}

		}
	}
}
