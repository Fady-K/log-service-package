namespace LogService.Formatting.FormattingStrategies
{
	/// <summary>
	/// The IFormateStrategy interface defines the structure for formatting strategies.
	/// It provides a contract that classes implementing this interface will provide a specific formatting implementation.
	/// </summary>
	public interface IFormateStrategy
	{
		/// <summary>
		/// Gets or sets the separator character used in the formatting process.
		/// </summary>
		string Sep { get; set; }

		/// <summary>
		/// Formats the input parameters into a specific format.
		/// </summary>
		/// <param name="param">An array of objects that contains zero or more objects to format.</param>
		/// <returns>Returns a formatted string.</returns>
		object Formate(params object[] param);
	}
}
