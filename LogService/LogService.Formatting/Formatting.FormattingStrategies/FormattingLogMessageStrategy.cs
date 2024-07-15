using System;
	
namespace LogService.Formatting.FormattingStrategies
{
	/// <summary>
	/// The FormatingLogMessageStrategy class provides an implementation of the IFormateStrategy interface.
	/// It formats log messages by appending each parameter to a string, separated by a specified separator.
	/// </summary>
	/// <remarks>
	/// This class is part of the LogService.Formatting.FormattingStrategies namespace.
	/// </remarks>
	/// <seealso cref="IFormatStrategy"/>
	public class FormattingLogMessageStrategy : IFormatStrategy
	{
		/* Fields */
		/// <summary>
		/// The separator used in the formatting process.
		/// </summary>
		protected string _sep;

		/// <summary>
		/// A flag indicating whether a DateTime object is given in the parameters.
		/// </summary>
		protected bool _isDataTimeGiven;


		/* Consructors */
		/// <summary>
		/// Default constructor for the FormatingLogMessageStrategy class.
		/// Initializes the separator to a space and the _isDataTimeGiven flag to false.
		/// </summary>
		public FormattingLogMessageStrategy()
        {
			// Init fields 
			_sep = " ";
			_isDataTimeGiven = false;
        }

		/// <summary>
		/// Constructor for the FormatingLogMessageStrategy class that allows specifying a custom separator.
		/// Initializes the separator to the provided value and the _isDataTimeGiven flag to false.
		/// </summary>
		/// <param name="sep">The separator to be used in the formatting process.</param>
		public FormattingLogMessageStrategy(string sep)
        {
			// Init fields 
			_sep = sep;
			_isDataTimeGiven = false;
        }


		/* Setters and getters (properties) */
		/// <summary>
		/// Gets or sets the separator used in the formatting process.
		/// </summary>
		public string Sep { get => _sep; set => _sep = value; }


		/* Implemened Methods  */
		/// <summary>
		/// Formats the input parameters into a specific format.
		/// </summary>
		/// <param name="param">An array of objects that contains zero or more objects to format.</param>
		/// <returns>Returns a formatted string.</returns>
		public object Formate(params object[] param)
		{
			string result = "";
			foreach(var item in param)
			{
				if (item is DateTime dateTime)
				{
					// Update datetime is given to true
					_isDataTimeGiven = true;
					
					// Append to restul
					result += FormateDateTime(dateTime) + _sep;
				}
				else
				{
					result += item.ToString() + _sep;
				}
			}

			// Check if Datatime isn't given
			if (!_isDataTimeGiven) 
			{
				// Add it to the begginge of the restul
				result = FormateDateTime(DateTime.Now) + _sep + result;
			}

			// Trim the result, then return it.
			if (char.TryParse(_sep, out char sepAsChar))
			{
				return result.TrimEnd(sepAsChar);
			}
			else
			{
				return result.Trim(_sep.ToCharArray());
			}
		}


		/////////////////////////////// Helper Methods //////////////////////////////
		/// <summary>
		/// Formats a DateTime object into a specific string format.
		/// </summary>
		/// <param name="dateTime">The DateTime object to format.</param>
		/// <returns>Returns a string representation of the DateTime object.</returns>
		protected string FormateDateTime(DateTime dateTime)
		{
			return dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
		}
	}
}
