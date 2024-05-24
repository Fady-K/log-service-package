using System.IO;
using System.Text.RegularExpressions;
using LogService.Validation.Core;


namespace LogService.Validation.Strategies
{
	public class LogFilePathWithoutExceptionsValidationStrategy : IValidationStrategy
	{
		/* Constants */
		protected const string REGEX_PATTERN = @"";

		/* Instance attributes */
		protected Regex _rgx;


		/* Constructors */
		public LogFilePathWithoutExceptionsValidationStrategy()
		{
			// Init instance attributes
			ValidationRegex = new Regex(REGEX_PATTERN);
		}


		/* Setters and getters */
		public Regex ValidationRegex { get { return _rgx; } protected set { _rgx = value; } }


		/* Instance methods */
		public ValidationResult Validate(object logFilePath)
		{
			// Validation result by default = false;
			bool exists = true;
			bool isValid = true;
			ValidationResult result = new ValidationResult();

			// Gen Key must be a string
			if (!(logFilePath is string))
			{
				return new ValidationResult(false, false);
			}
			else
			{
				// Cast the logFilePath explicitly into string and then check for other exceptions
				string logFilePathAsString = (string)logFilePath;

				// logFilePath can't be null or empty
				if (string.IsNullOrEmpty(logFilePathAsString))
				{
					return new ValidationResult(false, false);
				}

				// Check if the path matches the regex pattern
				if (!ValidationRegex.IsMatch(logFilePathAsString))
				{
					// throw an invalid path exception
					isValid = false;
					
				}

				// Check if file exists
				if (!File.Exists(logFilePathAsString))
				{
					exists = false;
				}



				// In case no exception were thrown then set validation result = true
				result = new ValidationResult(isValid, exists);
			}

			// Return validation result
			return result;
		}
	}
}
