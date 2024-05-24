using LogService.Validation.Enums;
using LogService.Validation.Factories;
using LogService.Validation.Strategies;

namespace LogService.Validation.Core
{
	public class Validator
	{
		/* Instance attributes */
		protected IValidationStrategy _validationStrategy;


        /* Constructors */
        public Validator(IValidationStrategy validationStrategy)
        {
            // Set the strategy
            ValidationStrategy = validationStrategy;
        }


        /* Setters and getters */
        public IValidationStrategy ValidationStrategy { get { return _validationStrategy; } set { _validationStrategy = value; } }


		/* Instance methods */
		public ValidationResult Validate(object input)
		{
			return _validationStrategy.Validate(input);
		}
		
		public static ValidationResult Validate(ValidationStartegyType type, object input)
        {
			return ValidationStrategyFactory.Create(type).Validate(input);
        }

		public static ValidationResult Validate(IValidationStrategy strategy, object input)
		{
			return strategy.Validate(input);
		}
	}
}
