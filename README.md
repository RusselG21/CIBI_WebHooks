# CIBI WebHooks

## Overview

This application provides webhook integration services for the CIBI system. It's built with .NET 9.0 and designed to efficiently receive, process, and handle webhook events from various external services, starting with Talkpush integration.

## Architecture

The application follows a vertical slice architecture approach with:

- **Services**: Background processing of webhook payloads
- **CQRS Pattern**: Using MediatR for command/query separation
- **Validation**: FluentValidation for input validation
- **Containerization**: Docker support for deployment

## Components

### Talkpush Webhook

- Processes incoming webhooks from Talkpush recruitment system
- Queues and processes payloads asynchronously
- Validates incoming data before processing

## Technical Stack

- .NET 9.0
- ASP.NET Core
- MediatR for CQRS implementation
- FluentValidation
- Carter for API endpoints
- Health checks for monitoring
- Docker containerization

## Getting Started

### Prerequisites

- .NET 9.0 SDK
- Docker (optional, for containerized deployment)
- Visual Studio 2022 or equivalent IDE

### Local Development

1. Clone the repository:

   ```
   git clone https://github.com/yourusername/CIBI_WebHooks.git
   cd CIBI_WebHooks
   ```

2. Build the solution:

   ```
   dotnet build
   ```

3. Run the Talkpush webhook service:
   ```
   cd src/Webhooks/Talkpush/Talkpush.api
   dotnet run
   ```

### Docker Deployment

You can use the provided Dockerfile to build and run the application in a container:

```bash
# From the src directory
docker build -t cibi-webhooks-talkpush -f Webhooks/Talkpush/Talkpush.api/Dockerfile .
docker run -p 8080:8080 cibi-webhooks-talkpush
```

## Project Structure

```
src/
├── BuildingBlocks/         # Shared components and utilities
└── Webhooks/
    └── Talkpush/           # Talkpush webhook integration
        └── Talkpush.api/   # API for Talkpush webhooks
```

## Configuration

The application uses standard ASP.NET Core configuration patterns. Update the `appsettings.json` file to configure:

- API endpoints
- Database connections
- Logging settings
- Health check options

## Health Checks

The application includes health checks to monitor system status:

```
GET /health
```

## Testing

The application includes unit tests built with xUnit, FluentAssertions, and Moq:

### Test Structure

```
tests/
└── WebhooksTest/
    ├── TalkPushTest/
    │   ├── Handler/             # Tests for command handlers
    │   └── Validation/          # Tests for input validators
    └── SharedResources/
        └── Fixtures/            # Test fixtures and mock setups
```

### Running Tests

```
cd tests/WebhooksTest
dotnet test
```

### Test Coverage

- Unit tests for validators ensure proper input validation
- Handler tests verify webhook payloads are properly queued
- Test fixtures provide reusable mock objects

## Contributing

Please follow the standard Git workflow:

1. Create a feature branch
2. Make your changes
3. Submit a pull request for review
4. Code review is implemented
