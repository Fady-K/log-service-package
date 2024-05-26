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
- Set up your development environment for .NET Framework with necessary compilers and libraries.
- **.NET Framework v4.8** for optimal performance.
- Ensure your application uses an `app.config` file, as this package relies on it for configuration.
- Include the `System.Configuration.ConfigurationManager` reference in your project. It's a system DLL that comes with .NET and can be added via the 'Add Reference' dialog in your development environment.

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
<details>
<summary>Class diagram</summary>
<img src="./Diagrams/class digram/LogService.drawio.png" alt="Alt Text">
</details>

<details>
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
The `LoggingService` class serves as the core of the logging system. It follows the Singleton design pattern, ensuring that only one instance exists in the application. This design guarantees centralized control over logging operations and facilitates consistent logging behavior throughout the application.

#### Abstract Logger

The `AbstractLogger` class is an abstract base class that provides common functionality for all logger classes in the application. It implements the Strategy design pattern, allowing different logging behaviors to be used interchangeably. The `AbstractLogger` class defines methods for logging messages and manages the interaction between log strategies and formatters.

#### Logger
The `Logger` class extends the `AbstractLogger` class and provides concrete implementation for logging messages. It allows developers to specify the desired log strategy and formatter during initialization, enabling customization of logging behavior based on specific requirements. Instances of the `Logger` class can be used independently to log messages or as part of the `LoggingService` infrastructure.

#### Log Strategy
Log strategies determine how and where log messages are handled within the logging system. The `ILogStrategy` interface defines the structure for different logging strategies, such as instant logging or accumulation-based logging. Concrete implementations of log strategies, such as `InstanteMessageLoggingStrategy` and `AccumulativeMessageBasedThresholdLoggingStrategy`, provide specific logic for logging messages instantly or accumulating them until a threshold is reached before flushing to a file.

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
