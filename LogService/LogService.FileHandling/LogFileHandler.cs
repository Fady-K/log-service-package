using System;
using System.Diagnostics;
using System.IO;
using LogService.Validation.Core;
using LogService.Validation.Strategies;

namespace LogService.FileHandling
{
	public class LogFileHandler : AbstractFileHandler
	{
		/* Constructors */
		public LogFileHandler(string vagueLogFilePath, string defaultLogFilePath) : base(vagueLogFilePath, defaultLogFilePath)
		{
		}

		/* Instance methods */
		protected override string Prepare(string vagueFilePath)
		{
			// Empty file path
			string validFilePath = "";

			try
			{
				ValidationResult vResult = Validator.Validate(new LogFilePathWithoutExceptionsValidationStrategy(), vagueFilePath);

				if (vResult.IsValid && vResult.Exists)
				{
					validFilePath = vagueFilePath;
				}
				else if (vResult.IsValid && !vResult.Exists)
				{
					// Set validlogfile path with the vague as it's valie
					validFilePath = vagueFilePath;

					// Create the directory for the given path, if it does not exist.
					string directoryPath = Path.GetDirectoryName(validFilePath);
					Directory.CreateDirectory(directoryPath);

					// Create file with the given name but check for extension first.
					using (File.Create(validFilePath)) { /* intentionally left blank */ }

				}
				else
				{
					// Create the directory for the given path, if it does not exist.
					string directoryPath = Path.GetDirectoryName(_fileDefaultPath);
					Directory.CreateDirectory(directoryPath);

					// Create file with the given name but check for extension first.
					validFilePath = _fileDefaultPath;
					using (File.Create(_fileDefaultPath)) { /* intentionally left blank */ };
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

			// Finally return the validPath
			return validFilePath;
		}


		public override void Clear()
		{
			// If file exists clear it
			try
			{
				File.WriteAllText(_fileValidPath, string.Empty);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public override void Delete()
		{
			//If file exists delete it
			try
			{
				File.Delete(_fileValidPath);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public override void Open()
		{
			try
			{
				Process.Start(new ProcessStartInfo(Path.GetFullPath(_fileValidPath)) { UseShellExecute = true });
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
