using LogService.Validation.Enums;
using LogService.Validation.Strategies;

namespace LogService.Validation.Factories
{
	/// <summary>
	/// The ValidationStrategyFactory class is a factory class that creates instances of IValidationStrategy.
	/// It implements the Factory Method design pattern.
	/// </summary>
	public class ValidationStrategyFactory
	{
		/// <summary>
		/// Creates an instance of IValidationStrategy based on the provided strategy type.
		/// </summary>
		/// <param name="strategyType">The type of the validation strategy to create.</param>
		/// <returns>Returns an instance of IValidationStrategy. If the strategy type does not match any known types, it returns null.</returns>
		/// <seealso cref="IValidationStrategy"/>
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
