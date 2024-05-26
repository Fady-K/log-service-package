# log-service-package

`LogService` is a flexible and extensible logging service for .NET applications. It provides different logging strategies and formatting options, making it easy to log messages in a way that suits your application's needs.

## Table of Contents
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Configuration](#configuration)
- [Customization](#customization)
- [Deployment](#deployment)
- [Teammates](#teammates)
- [License](#license)
- 
### Prerequisites

- .NET Framework

### Installation

1. Download the `LogService` package.
2. Add a reference to the `LogService.dll` in your project.

### Usage

Here's a basic example of how to use `LogService`:

```csharp
// By LogService singleton
LoggingService.GetInstance().Log(DateTime.Now, MessageType, "This is a log message");

// By instanciating from Logger class
var logger = new Logger(new InstanteMessageLoggingStrategy("path_to_log_file"), new LogMessageFormatter());

// Log a message
logger.Log("This is a log message", "Info", "etc");
