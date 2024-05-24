using LogService.Validation.Enums;
using LogService.Validation.Strategies;

namespace LogService.Validation.Factories
{
    public class ValidationStrategyFactory
	{
		public static IValidationStrategy Create(ValidationStartegyType strategyType)
		{
			if (strategyType.Equals(ValidationStartegyType.DownloadPathValidation))
			{
				return null;
			}
			else if (strategyType.Equals(ValidationStartegyType.YoutubeURLValidation))
			{
				return null;
			}
			else
			{
				return null;
			}
		}
	}
}
