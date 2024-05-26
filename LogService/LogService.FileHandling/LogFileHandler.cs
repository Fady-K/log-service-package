using System;
using System.Diagnostics;
using System.IO;
using LogService.Validation.Core;
using LogService.Validation.Strategies;

namespace LogService.FileHandling
{
	/// <summary>
	/// The LogFileHandler class.
	/// This class is responsible for handling log file. It extends the AbstractFileHandler class and provides implementations for the abstract methods.
	/// </summary>
	/// <remarks>
	/// This class can create, clear, delete, and open log files. It also prepares a valid file path for the log file.
	/// </remarks>
	/// <seealso cref="AbstractFileHandler"/>
	public class LogFileHandler : AbstractFileHandler
	{
		/* Constructors */

		/// <summary>
		/// Constructor with parameters (Paramerized).
		/// Initializes a new instance of the LogFileHandler class with the specified vague and default log file paths.
		/// </summary>
		/// <param name="vagueLogFilePath">The vague path of the log file.</param>
		/// <param name="defaultLogFilePath">The default path of the log file.</param>
		public LogFileHandler(string vagueLogFilePath, string defaultLogFilePath) : base(vagueLogFilePath, defaultLogFilePath)
		{
		}

		/* Instance methods */

		/// <summary>
		/// Prepares a valid file path for the log file.
		/// </summary>
		/// <param name="vagueFilePath">The vague file path to prepare.</param>
		/// <returns>The prepared valid file path.</returns>
		/// <exception cref="Exception">Throws an exception if an error occurs while preparing the file path.</exception>
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

		/// <summary>
		/// Clears the log file.
		/// </summary>
		/// <exception cref="Exception">Throws an exception if an error occurs while clearing the log file.</exception>
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

		/// <summary>
		/// Deletes the log file.
		/// </summary>
		/// <exception cref="Exception">Throws an exception if an error occurs while deleting the log file.</exception>
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

		/// <summary>
		/// Opens the log file.
		/// </summary>
		/// <exception cref="Exception">Throws an exception if an error occurs while opening the log file.</exception>
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
