using System.IO;
using System.Text.RegularExpressions;
using LogService.Validation.Core;
using LogService.Validation.Exceptions;

namespace LogService.Validation.Strategies
{
	/// <summary>
	/// The LogFilePathValidationStrategy class provides an implementation of the IValidationStrategy interface.
	/// It validates log file paths by checking if the path is a string, is not null or empty, matches a specific regex pattern, and if the file exists.
	/// </summary>
	/// <seealso cref="IValidationStrategy"/>
	public class LogFilePathValidationStrategy : IValidationStrategy
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
		/// Default constructor for the LogFilePathValidationStrategy class.
		/// Initializes the ValidationRegex to a new Regex object with the REGEX_PATTERN.
		/// </summary>
		public LogFilePathValidationStrategy()
		{
			ValidationRegex = new Regex(LogFilePathValidationStrategy.REGEX_PATTERN);
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
		/// <exception cref="ValidationException">Thrown when the logFilePath is not a string, is null or empty, does not match the regex pattern, or if the file does not exist.</exception>
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
