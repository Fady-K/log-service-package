using System;
	
namespace LogService.Formatting.FormattingStrategies
{ 
	public class FormatingLogMessageStrategy : IFormateStrategy
	{
		protected  string _sep = " ";
		protected bool _isDataTimeGiven = false;
		public string Sep { get => _sep; set => _sep = value; }

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


		///
		protected string FormateDateTime(DateTime dateTime)
		{
			return dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
		}
	}
}
