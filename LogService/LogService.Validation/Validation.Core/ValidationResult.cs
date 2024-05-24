namespace LogService.Validation.Core 
{ 
	/// <summary>
	/// Immutable object
	/// </summary>
	public class ValidationResult
	{
		/* Instance attributes */
		private readonly bool _isValid;
        private readonly bool _exists;

        /* Constructors */
        public ValidationResult(bool validationResult=false, bool exists=false)
        {
            _isValid = validationResult;
            _exists = exists;
        }

        /* Setters and getters */
        public bool IsValid { get { return _isValid; } }
        public bool Exists { get { return _exists; } }
    }
}
