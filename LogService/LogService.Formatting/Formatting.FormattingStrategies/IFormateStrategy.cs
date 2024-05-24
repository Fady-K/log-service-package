namespace LogService.Formatting.FormattingStrategies
{
	public interface IFormateStrategy
	{
        string Sep { get; set; }
        object Formate(params object[] param);
	}
}
