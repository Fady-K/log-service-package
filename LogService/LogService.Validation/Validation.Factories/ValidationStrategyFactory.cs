using LogService.Validation.Enums;
using LogService.Validation.Strategies;

namespace LogService.Validation.Factories
{
    public class ValidationStrategyFactory
	{
		public static IValidationStrategy Create(ValidationStartegyType strategyType)
		{
			if (strategyType.Equals(ValidationStartegyType.LogFilePathValidation))
			{
				return new LogFilePathValidationStrategy();
			}
			else if (strategyType.Equals(ValidationStartegyType.LogFilePathWithoutExceptionsValidation))
			{
				return new LogFilePathWithoutExceptionsValidationStrategy();
			}
			else
			{
				return null;
			}
		}
	}
}
