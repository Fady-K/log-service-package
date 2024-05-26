using LogService.Formatting.FormattingStrategies;
using System;

namespace LogService.Formatting.Core
{
	/// <summary>
	/// The AbstractFormatter class.
	/// This is an abstract base class for all formatter classes in the application.
	/// It provides common functionality for formatting.
	/// </summary>
	/// <remarks>
	/// This class uses the Strategy design pattern to allow different formatting behaviors to be used interchangeably.
	/// </remarks>
	/// <seealso cref="IFormateStrategy"/>
	public abstract class AbstractFormatter
	{
		/* Fields */

		/// <summary>
		/// The format strategy used by this formatter.
		/// This determines how log messages are formatted.
		/// </summary>
		/// <seealso cref="IFormateStrategy"/>
		protected IFormateStrategy _formateStrategy;


		/* Constructors */

		/// <summary>
		/// Default constructor.
		/// Initializes a new instance of the AbstractFormatter class with a default format strategy.
		/// </summary>
		public AbstractFormatter()
		{
			_formateStrategy = new DefaultFormattingStrategy();
		}

		/// <summary>
		/// Constructor with parameters.
		/// Initializes a new instance of the AbstractFormatter class with the specified format strategy.
		/// </summary>
		/// <param name="formateStrategy">The format strategy to use.</param>
		public AbstractFormatter(IFormateStrategy formateStrategy)
		{
			_formateStrategy = formateStrategy;
		}


		/* Setters and getters */

		/// <summary>
		/// Gets or sets the format strategy used by this formatter.
		/// </summary>
		public IFormateStrategy FormateStrategy { get => _formateStrategy; set => _formateStrategy = value; }


		/* Instance methods */

		/// <summary>
		/// Formats a series of objects into a single string.
		/// </summary>
		/// <param name="param">The objects to format.</param>
		/// <returns>The formatted string.</returns>
		/// <exception cref="Exception">Throws an exception if an error occurs while formatting the objects.</exception>
		public object Formate(params object[] param)
		{
			try
			{
				return _formateStrategy.Formate(param);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
