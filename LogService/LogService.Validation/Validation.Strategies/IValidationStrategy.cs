using LogService.Validation.Core;

namespace LogService.Validation.Strategies
{
	public interface IValidationStrategy
	{
		ValidationResult Validate(object input);
	}
}
