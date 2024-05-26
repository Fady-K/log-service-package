using System.IO;
using System.Text.RegularExpressions;
using LogService.Validation.Core;

namespace LogService.Validation.Strategies
{
	/// <summary>
	/// The LogFilePathWithoutExceptionsValidationStrategy class provides an implementation of the IValidationStrategy interface.
	/// It validates log file paths by checking if the path is a string, is not null or empty, matches a specific regex pattern, and if the file exists.
	/// Unlike the LogFilePathValidationStrategy, this class does not throw exceptions but instead returns a ValidationResult object with the validation result.
	/// </summary>
	/// <seealso cref="IValidationStrategy"/>
	public class LogFilePathWithoutExceptionsValidationStrategy : IValidationStrategy
	{
		/// <summary>
		/// The regex pattern used in the validation process.
		/// </summary>
		protected const string REGEX_PATTERN = @"";

		/// <summary>
		/// The Regex object used in the validation process.
		/// </summary>
		protected Regex _rgx;

		/// <summary>
		/// Default constructor for the LogFilePathWithoutExceptionsValidationStrategy class.
		/// Initializes the ValidationRegex to a new Regex object with the REGEX_PATTERN.
		/// </summary>
		public LogFilePathWithoutExceptionsValidationStrategy()
		{
			ValidationRegex = new Regex(REGEX_PATTERN);
		}

		/// <summary>
		/// Gets or sets the Regex object used in the validation process.
		/// </summary>
		public Regex ValidationRegex { get { return _rgx; } protected set { _rgx = value; } }

		/// <summary>
		/// Validates the log file path.
		/// </summary>
		/// <param name="logFilePath">The log file path to validate.</param>
		/// <returns>Returns a ValidationResult object that indicates whether the validation was successful and any additional information.</returns>
		/// <seealso cref="ValidationResult"/>
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
