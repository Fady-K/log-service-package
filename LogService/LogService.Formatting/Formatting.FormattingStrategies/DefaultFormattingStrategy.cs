namespace LogService.Formatting.FormattingStrategies
{
	// <summary>
	/// The DefaultFormattingStrategy class provides a default implementation of the IFormateStrategy interface.
	/// It formats log messages by appending each parameter to a string, separated by a specified separator.
	/// </summary>
	/// <seealso cref="IFormateStrategy"/>
	public class DefaultFormattingStrategy : IFormateStrategy
	{
		/* Insatnce attributes */

		/// <summary>
		/// The separator used in the formatting process.
		/// </summary>
		protected string _sep;


		/* Constructors */

		/// <summary>
		/// Default constructor for the DefaultFormattingStrategy class.
		/// Initializes the separator to a hyphen (-).
		/// </summary>
		public DefaultFormattingStrategy()
        {
			_sep = "-";
        }

		/* Setters and getters */

		/// <summary>
		/// Gets or sets the separator used in the formatting process.
		/// </summary>
		public string Sep { get => _sep; set => _sep = value; }


		/* Instance methods */

		/// <summary>
		/// Formats the input parameters into a specific format.
		/// </summary>
		/// <param name="param">An array of objects that contains zero or more objects to format.</param>
		/// <returns>Returns a formatted string.</returns>
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
