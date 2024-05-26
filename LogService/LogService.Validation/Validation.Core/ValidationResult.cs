namespace LogService.Validation.Core 
{
	/// <summary>
	/// The ValidationResult class is an immutable object that represents the result of a validation operation.
	/// It contains two properties: IsValid and Exists.
	/// </summary>
	public class ValidationResult
	{
		/* Instance attributes */
		/// <summary>
		/// Indicates whether the validation was successful.
		/// </summary>
		private readonly bool _isValid;

		/// <summary>
		/// Indicates whether the validated object exists.
		/// </summary>
		private readonly bool _exists;

		/* Constructors */
		/// <summary>
		/// Initializes a new instance of the ValidationResult class with the specified validation result and existence.
		/// </summary>
		/// <param name="validationResult">Indicates whether the validation was successful. The default value is false.</param>
		/// <param name="exists">Indicates whether the validated object exists. The default value is false.</param>
		public ValidationResult(bool validationResult = false, bool exists = false)
		{
			_isValid = validationResult;
			_exists = exists;
		}

		/* Setters and getters */
		/// <summary>
		/// Gets a value indicating whether the validation was successful.
		/// </summary>
		public bool IsValid { get { return _isValid; } }

		/// <summary>
		/// Gets a value indicating whether the validated object exists.
		/// </summary>
		public bool Exists { get { return _exists; } }
	}
}
