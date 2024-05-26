using System;

namespace LogService.Validation.Exceptions
{
	/// <summary>
	/// The ValidationException class represents errors that occur during application execution related to validation.
	/// This class is derived from the System.Exception class.
	/// </summary>
	public class ValidationException : Exception
	{
		/* Constants */
		/// <summary>
		/// The suffix added to every exception message.
		/// </summary>
		public const string EXCEPTION_SUFFIX = nameof(ValidationException) + ": ";


		/* Instance attributes */
		/// <summary>
		/// The message that describes the error.
		/// </summary>
		private string _msg;


		/* Constructors */
		/// <summary>
		/// Initializes a new instance of the ValidationException class with a specified error message.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		public ValidationException(string message)             // Paramerized constructor
		{
			InitMessageAttr(message);
		}


		/* Getters */

		/// <summary>
		/// Gets a message that describes the current exception.
		/// </summary>
		public override string Message => _msg;



		//////////////////////////////////////// Helper methods  //////////////////////////////////////
		/// <summary>
		/// Initializes the _msg field with the provided message.
		/// If the message does not start with the EXCEPTION_SUFFIX, it adds the suffix to the message.
		/// </summary>
		/// <param name="message">The message to initialize the _msg field with.</param>
		private void InitMessageAttr(string message)
        {
			// Add this suffix to every excpetion if doesn't exists
			if (!message.StartsWith(EXCEPTION_SUFFIX))
			{
				// Add the suffex
				message = EXCEPTION_SUFFIX + message;
			}

			// Init instance attribute
			_msg = message;
		}
	}
}
