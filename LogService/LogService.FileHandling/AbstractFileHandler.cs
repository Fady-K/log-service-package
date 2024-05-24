namespace LogService.FileHandling
{
	/// <summary>
	/// The AbstractFileHandler class is an abstract base class that provides a common interface for file handling operations.
	/// This class is designed to be extended by concrete classes that provide specific implementations for different types of files.
	/// </summary>
	public abstract class AbstractFileHandler
	{
		/// <summary>
		/// The _fileValidPath field stores the valid path to the file.
		/// </summary>
		protected string _fileValidPath;

		/// <summary>
		/// The _fileDefaultPath field stores the default path to the file.
		/// </summary>
		protected string _fileDefaultPath;

		/// <summary>
		/// The default constructor initializes the _fileValidPath and _fileDefaultPath fields to empty strings.
		/// </summary>
		public AbstractFileHandler()
		{
			_fileValidPath = string.Empty;
			_fileDefaultPath = string.Empty;
		}

		/// <summary>
		/// This constructor initializes the _fileValidPath field with the result of the Prepare method and the _fileDefaultPath field with the provided default file path.
		/// </summary>
		/// <param name="vagueFilePath">A vague path to the file.</param>
		/// <param name="defaultFilePath">A default path to the file.</param>
		public AbstractFileHandler(string vagueFilePath, string defaultFilePath)
		{
			_fileValidPath = Prepare(vagueFilePath);
			_fileDefaultPath = defaultFilePath;
		}

		/// <summary>
		/// The FileValidPath property gets or sets the _fileValidPath field.
		/// </summary>
		public string FileValidPath { get => _fileValidPath; set => _fileValidPath = value; }

		/// <summary>
		/// The FileDefaultPath property gets or sets the _fileDefaultPath field.
		/// </summary>
		public string FileDefaultPath { get => _fileDefaultPath; set => _fileDefaultPath = value; }

		/// <summary>
		/// The Prepare method is an abstract method that prepares the file handler.
		/// This method must be implemented by any class that extends AbstractFileHandler.
		/// </summary>
		/// <param name="vagueFilePath">A vague path to the file.</param>
		/// <returns>A string representing the valid file path.</returns>
		protected abstract string Prepare(string vagueFilePath);

		/// <summary>
		/// The Open method is an abstract method that opens the file.
		/// This method must be implemented by any class that extends AbstractFileHandler.
		/// </summary>
		public abstract void Open();

		/// <summary>
		/// The Delete method is an abstract method that deletes the file.
		/// This method must be implemented by any class that extends AbstractFileHandler.
		/// </summary>
		public abstract void Delete();

		/// <summary>
		/// The Clear method is an abstract method that clears the contents of the file.
		/// This method must be implemented by any class that extends AbstractFileHandler.
		/// </summary>
		public abstract void Clear();
	}
}
