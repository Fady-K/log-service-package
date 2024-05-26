# LogService

## Class Diagram

Here is a class diagram showing the main classes in the LogService library:

!Class Diagram

## File Structure

Here is the file structure of the LogService library:


## Getting Started

### Prerequisites

- .NET Framework

### Installation

1. Download the `LogService` package.
2. Add a reference to the `LogService.dll` in your project.

### Usage

Here's a basic example of how to use `LogService`:

```csharp
// By LogService singleton
LoggingService.GetInstance().Log();

// By instanciating from Logger class
var logger = new Logger(new InstanteMessageLoggingStrategy("path_to_log_file"), new LogMessageFormatter());

// Log a message
logger.Log("This is a log message", MessageType.Info);
