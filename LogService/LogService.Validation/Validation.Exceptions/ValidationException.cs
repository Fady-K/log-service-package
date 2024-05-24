using System;

namespace LogService.Validation.Exceptions
{
	public class ValidationException : Exception
	{
        /* Constants */
        public const string EXCEPTION_SUFFIX = nameof(ValidationException) + ": ";


        /* Instance attributes */
        private string _msg;


        /* Constructors */
        public ValidationException(string message)             // Paramerized constructor
		{
			InitMessageAttr(message);
		}


        /* Getters */
        public override string Message => _msg;



        //////////////////////////////////////// Helper methods  //////////////////////////////////////
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
