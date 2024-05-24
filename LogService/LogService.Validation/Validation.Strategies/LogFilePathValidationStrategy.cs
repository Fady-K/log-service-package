using System.IO;
using System.Text.RegularExpressions;
using LogService.Validation.Core;
using LogService.Validation.Exceptions;
using LogService.Validation.Strategies;

namespace ValidationStrategies
{
	public class LogFilePathValidationStrategy : IValidationStrategy
	{
		/* Constants */
		protected const string REGEX_PATTERN = @"";

		/* Instance attributes */
		protected Regex _rgx;


		/* Constructors */
		public LogFilePathValidationStrategy()
		{
			// Init instance attributes
			ValidationRegex = new Regex(LogFilePathValidationStrategy.REGEX_PATTERN);
		}


		/* Setters and getters */
		public Regex ValidationRegex { get { return _rgx; } protected set { _rgx = value; } }


		/* Instance methods */
		public ValidationResult Validate(object logFilePath)
		{
			// Validation result by default = false;
			bool exists = false;
			ValidationResult result = new ValidationResult();

			// Gen Key must be a string
			if (!(logFilePath is string))
			{
				throw new ValidationException("logFilePath must be a string!");
			}
			else
			{
				// Cast the logFilePath explicitly into string and then check for other exceptions
				string logFilePathAsString = (string)logFilePath;

				// logFilePath can't be null or empty
				if (string.IsNullOrEmpty(logFilePathAsString))
				{
					throw new ValidationException("logFilePath can't be null or empty!");
				}

				// Check if the path matches the regex pattern
				if (!ValidationRegex.IsMatch(logFilePathAsString))
				{
					// throw an invalid path exception
					throw new ValidationException($"invalid logFilePath!");
				}

				// Check if file exists
				if (!File.Exists(logFilePathAsString))
				{
					throw new ValidationException($"{logFilePathAsString} file doesn't exist!");
				}
				else
				{
					exists = true;
				}


				// In case no exception were thrown then set validation result = true
				result = new ValidationResult(true, exists);
			}

			// Return validation result
			return result;
		}
	}
}
