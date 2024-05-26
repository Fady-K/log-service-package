using LogService.Validation.Core;

namespace LogService.Validation.Strategies
{
	/// <summary>
	/// The IValidationStrategy interface defines the structure for validation strategies.
	/// It provides a contract that classes implementing this interface will provide a specific validation implementation.
	/// </summary>
	public interface IValidationStrategy
	{
		/// <summary>
		/// Validates the input object.
		/// </summary>
		/// <param name="input">The object to validate.</param>
		/// <returns>Returns a ValidationResult object that indicates whether the validation was successful and any additional information.</returns>
		/// <seealso cref="ValidationResult"/>
		ValidationResult Validate(object input);
	}
}
