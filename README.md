# log-service-package
`LogService` is a flexible and extensible logging service for .NET applications. It provides different logging strategies and formatting options, making it easy to log messages in a way that suits your application's needs.

## Table of Contents
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Design and Structure](#design-and-structure)
  - [Diagrams](#diagrams)
  - [Components Overview](#components-overview)
- [Configuration](#configuration)
- [Deployment](#deployment)
- [Author](#author)
- [License](#license)

## Prerequisites
Before you start using `LogService` in your project, make sure you have the following prerequisites set up:
1. **Development Environment for .NET Framework**:
   - Ensure that you have a development environment configured for .NET Framework. This includes having the necessary compilers and libraries installed.
   - If you haven't already, download and install the latest version of the .NET Framework SDK.

2. **.NET Framework v4.8**:
   - For optimal performance and compatibility, use **.NET Framework version 4.8** or later.
   - If you're not sure which version you have, you can check it using the following command in your terminal or command prompt:
     ```
     dotnet --version
     ```
     Make sure the output indicates version 4.8 or higher.

3. **`app.config` File**:
   - Ensure that your application uses an `app.config` file. `LogService` relies on this configuration file to manage its settings.
   - If your project doesn't have an `app.config` file, create one in the root directory of your project.

4. **`System.Configuration.ConfigurationManager` Reference**:
   - Add a reference to the `System.Configuration.ConfigurationManager` assembly in your project.
   - This assembly is a system DLL that comes with .NET and provides access to configuration settings.
   - You can add this reference via the 'Add Reference' dialog in your development environment.

By meeting these prerequisites, you'll be ready to integrate and configure `LogService` seamlessly 😊

## Installation
1. Download the `LogService` package.
2. Add a reference to the `LogService.dll` in your project.

## Usage
Here's a basic example of how to use `LogService`:
```csharp
// Using the LogService singleton
LoggingService.GetInstance().Log(DateTime.Now, MessageType, "This is a log message");

// By instantiating the Logger class
var logger = new Logger(new InstantMessageLoggingStrategy("path_to_log_file"), new LogMessageFormatter());

// Log a message
logger.Log("This is a log message", "Info", "Additional context if needed");
```

## Design and Structure
`LogService` is designed with flexibility and extensibility in mind, utilizing various components to meet diverse logging requirements.

### Diagrams
<details open>
<summary>Class diagram</summary>
<img src="./Diagrams/class digram/LogService.drawio.png" alt="Alt Text">
</details>

<details open>
<summary>Package components tree</summary>
<pre>
+---LogService.Core
¦   +---AbstractLogger.cs
¦   +---Logger.cs
¦   +---LoggingService.cs
¦   +---LogStartegies
¦       +---AccumulativeMessageBasedThresholdLoggingStrategy.cs
¦       +---ILogStrategy.cs
¦       +---InstanteMessageLoggingStrategy.cs
¦
+---LogService.FileHandling
¦   +---AbstractFileHandler.cs
¦   +---LogFileHandler.cs
¦
+---LogService.Formatting
¦   +---Formatting.Core
¦   ¦   +---AbstractFormatter.cs
¦   ¦   +---LogMessageFormatter.cs
¦   +---Formatting.FormattingStrategies
¦       +---DefaultFormattingStrategy.cs
¦       +---FormatingLogMessageStrategy.cs
¦       +---IFormateStrategy.cs
¦
+---LogService.Validation
    +---Validation.Core
    ¦   +---ValidationResult.cs
    ¦   +---Validator.cs
    +---Validation.Enums
    ¦   +---ValidationStartegyType.cs
    +---Validation.Exceptions
    ¦   +---ValidationException.cs
    +---Validation.Factories
    ¦   +---ValidationStrategyFactory.cs
    +---Validation.Strategies
        +---IValidationStrategy.cs
        +---LogFilePathValidationStrategy.cs
        +---LogFilePathWithoutExceptionsValidationStrategy.cs
</pre>
</details>

### Components Overview
#### LoggingService
The `LoggingService` class is responsible for logging messages. It uses an `AbstractLogger` for logging and an `AbstractFileHandler` for file handling. This class follows the Singleton design pattern to ensure that only one instance of `LoggingService` exists in the application.

This class has several key fields:
- `_logFilePath`: The path of the log file.
- `_defaultLogFilePath`: The default path of the log file.
- `_logger`: The logger used by this service.
- `_fileHandler`: The file handler used by this service.

The class provides a default constructor that initializes a new instance of the `LoggingService` class and sets up the logger and file handler.

In addition, it provides getters for the `LogFilePath`, `DefaultLogFilePath`, `Logger`, and `FileHandler` fields. It also includes a method for logging a series of objects (`Log`).

The `GetInstance` static method is used to get the single instance of the `LoggingService` class.

Here is a simple example of how to use this class in C#:

```csharp
// Get the instance of the LoggingService class
LoggingService loggingService = LoggingService.GetIntance();

// Log a message
loggingService.Log("This is a test log message.");
```

#### AbstractLogger
The `AbstractLogger` class is an abstract base class for all logger classes in the application. It provides common functionality for logging messages, including formatting and flushing logs. This class uses the Strategy design pattern to allow different logging and formatting behaviors to be used interchangeably.

This class has two key fields:
- `_logStrategy`: The log strategy used by this logger. This determines how log messages are handled (e.g., how and when they are written to a log file or other storage).
- `_formatter`: The formatter used by this logger. This determines how log messages are formatted before they are logged.

The class provides two constructors:
- A default constructor that initializes a new instance of the `AbstractLogger` class with a default log message formatter.
- A constructor with parameters that initializes a new instance of the `AbstractLogger` class with the specified log strategy and formatter.

In addition, it provides setters and getters for the `LogStrategy` and `Formatter` fields. It also includes a virtual method for logging a series of objects (`Log`). The objects are formatted into a single message and then logged using the current log strategy.

Here is a simple example of how to use a class that extends this abstract class in C#:

```csharp
// Assume MyLogger is a class that extends AbstractLogger, and MyLogStrategy and MyFormatter are classes that implement ILogStrategy and AbstractFormatter respectively
MyLogStrategy logStrategy = new MyLogStrategy("path_to_your_log_file");
MyFormatter formatter = new MyFormatter();

// Create a new instance of the MyLogger class
MyLogger logger = new MyLogger(logStrategy, formatter);

// Log a message
logger.Log("This is a test log message.");
```
#### Logger
The `Logger` class provides logging functionality and is responsible for logging messages. It inherits from the `AbstractLogger` class, which provides common functionality for all logger classes in the application.

This class has a constructor that initializes a new instance of the `Logger` class with the specified log strategy and formatter. The `logStrategy` parameter specifies the log strategy to be used by this `Logger` instance, and the `formatter` parameter specifies the formatter to be used by this `Logger` instance.

Here is a simple example of how to use this class in C#:

```csharp
// Assume MyLogStrategy and MyFormatter are classes that implement ILogStrategy and AbstractFormatter respectively
MyLogStrategy logStrategy = new MyLogStrategy("path_to_your_log_file");
MyFormatter formatter = new MyFormatter();

// Create a new instance of the Logger class
Logger logger = new Logger(logStrategy, formatter);

// Log a message
logger.Log("This is a test log message.");
```

<details open>
<summary> Log Strategies </summary>

#### ILogStrategy
Log strategies determine how and where log messages are handled within the logging system. The `ILogStrategy` interface defines the structure for different logging strategies, such as instant logging or accumulation-based logging. Concrete implementations of log strategies, such as `InstanteMessageLoggingStrategy` and `AccumulativeMessageBasedThresholdLoggingStrategy`, provide specific logic for logging messages instantly or accumulating them until a threshold is reached before flushing to a file.

#### InstantMessageLoggingStrategy
The `InstantMessageLoggingStrategy` class is an implementation of the `ILogStrategy` interface. This strategy takes a log message and logs it instantly.

This class has a key attribute:
- `_validLogFilePath`: The valid path to the log file.

The class provides a constructor that initializes a new instance of the `InstantMessageLoggingStrategy` class with the specified log file path.

In addition, it provides a setter and getter for the `ValidLogFilePath` field. It also includes a method for logging messages (`Log`).

This class can be used as part of the `LoggingService` infrastructure to provide a specific logging behavior based on the immediate logging of messages. It ensures that all log messages are written to the log file instantly. This strategy can be particularly useful in scenarios where the immediate logging of each message is required. By logging messages instantly, this strategy can help ensure that all log messages are captured and stored accurately and promptly.

Here is a simple example of how to use this class in C#:

```csharp
// Create a new instance of the InstantMessageLoggingStrategy class
InstantMessageLoggingStrategy logger = new InstantMessageLoggingStrategy("path_to_your_log_file");

// Log a message
logger.Log("This is a test log message.");
```
#### AccumulativeMessageBasedThresholdLoggingStrategy
The `AccumulativeMessageBasedThresholdLoggingStrategy` class is an implementation of the `ILogStrategy` interface. It accumulates log messages and writes them to a log file when the system is closed or when the number of log messages reaches a specified threshold. This class provides a log strategy that logs the accumulated message when the system is closed.

This class has several key attributes:
- `_validLogFilePath`: The valid path to the log file.
- `_logs`: The list of accumulated log messages.
- `_flushingThreshold`: The threshold for flushing the accumulated log messages to the log file.

The class also provides a constructor that initializes a new instance of the `AccumulativeMessageBasedThresholdLoggingStrategy` class with the specified log file path and messages count threshold.

In addition, it provides setters and getters for the `ValidLogFilePath`, `FlushingThreshold`, and `Logs` fields. It also includes methods for logging messages (`Log`), handling the `ProcessExit` event of the current application domain (`CurrentDomain_ProcessExit`), and writing all accumulated log messages to the log file (`FlushToLogFile`).

This class can be used as part of the `LoggingService` infrastructure to provide a specific logging behavior based on the accumulation of messages and a defined threshold. It ensures that all log messages are stored and written to the log file, either when the system is closed or when the number of log messages reaches the specified threshold. This strategy can be particularly useful in scenarios where the frequency of log messages is high and immediate writing to the log file for each message could impact system performance. By accumulating messages and writing them in batches, this strategy can help optimize logging operations and system performance.
</details>



## Configuration
`LogService` uses the `app.config` file for its configuration, so make sure that your project includes an `app.config` file. Below, you'll find an example of how to set up the `app.config` file to configure `LogService` in your project.

### Configuration Settings
In your `app.config` file, make sure you have an `<appSettings>` section. Add the following key-value pairs under it:

1. **`log_file_path`**: This key specifies the path where the log file will be stored. You can customize this path according to your project's requirements. For example:

    ```xml
    <appSettings>
        <add key="log_file_path" value="./Log/Log.txt"/>
    </appSettings>
    ```

    Make sure to adjust the value to the desired log file path.

2. **`log_file_default_path`**: This key should remain unchanged. It specifies the default log file path. Keep it as follows:
    ```xml
    <appSettings>
        <add key="log_file_default_path" value="./Log/Log.txt"/>
    </appSettings>
    ```
    
Below is an example of how the `<appSettings>` section in your `app.config` file might look:
```xml
<configuration>
  <appSettings>
    <!-- Customize the log file path -->
    <add key="log_file_path" value="./Log/Log.txt"/>
    <!-- Keep the default log file path unchanged -->
    <add key="log_file_default_path" value="./Log/Log.txt"/>
    <!-- Add other configuration settings as needed -->
  </appSettings>
</configuration>
```
## Deployment
## Author
## License
This project is licensed under the [MIT License](LICENSE).
