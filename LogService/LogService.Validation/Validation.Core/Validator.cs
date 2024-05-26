using LogService.Validation.Enums;
using LogService.Validation.Factories;
using LogService.Validation.Strategies;

namespace LogService.Validation.Core
{
	/// <summary>
	/// The Validator class is responsible for validating objects using a specified validation strategy.
	/// It provides methods to validate an object using either an instance validation strategy or a static validation strategy.
	/// </summary>
	public class Validator
	{
		/* Instance attributes */
		/// <summary>
		/// The validation strategy used by this Validator instance.
		/// </summary>
		protected IValidationStrategy _validationStrategy;


		/* Constructors */
		/// <summary>
		/// Initializes a new instance of the Validator class with the specified validation strategy.
		/// </summary>
		/// <param name="validationStrategy">The validation strategy to be used by this Validator instance.</param>
		/// <seealso cref="IValidationStrategy"/>
		public Validator(IValidationStrategy validationStrategy)
        {
            // Set the strategy
            ValidationStrategy = validationStrategy;
        }


		/* Setters and getters */
		/// <summary>
		/// Gets or sets the validation strategy used by this Validator instance.
		/// </summary>
		public IValidationStrategy ValidationStrategy { get { return _validationStrategy; } set { _validationStrategy = value; } }


		/* Instance methods */

		/// <summary>
		/// Validates an object using the instance validation strategy.
		/// </summary>
		/// <param name="input">The object to validate.</param>
		/// <returns>Returns a ValidationResult object that indicates whether the validation was successful and any additional information.</returns>
		/// <seealso cref="ValidationResult"/>
		public ValidationResult Validate(object input)
		{
			return _validationStrategy.Validate(input);
		}


		/// <summary>
		/// Validates an object using a static validation strategy specified by a ValidationStartegyType.
		/// </summary>
		/// <param name="type">The type of the validation strategy to use.</param>
		/// <param name="input">The object to validate.</param>
		/// <returns>Returns a ValidationResult object that indicates whether the validation was successful and any additional information.</returns>
		/// <seealso cref="ValidationStrategyFactory"/>
		/// <seealso cref="ValidationResult"/>
		/// <seealso cref="ValidationStartegyType"/>
		public static ValidationResult Validate(ValidationStartegyType type, object input)
        {
			return ValidationStrategyFactory.Create(type).Validate(input);
        }


		/// <summary>
		/// Validates an object using a specified static validation strategy.
		/// </summary>
		/// <param name="strategy">The validation strategy to use.</param>
		/// <param name="input">The object to validate.</param>
		/// <returns>Returns a ValidationResult object that indicates whether the validation was successful and any additional information.</returns>
		/// <seealso cref="ValidationResult"/>
		/// <seealso cref="IValidationStrategy"/>
		public static ValidationResult Validate(IValidationStrategy strategy, object input)
		{
			return strategy.Validate(input);
		}
	}
}
