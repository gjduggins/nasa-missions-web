# NASA Missions Website

This is an ASP.NET Core web application for displaying information about NASA missions.

## Features
- View current and past NASA missions
- Detailed mission information
- Search functionality
- Admin panel for managing mission data

## Technologies Used
- ASP.NET Core MVC
- Entity Framework Core
- Bootstrap 5
- SQLite database

## Getting Started

### Prerequisites
- .NET 6.0 SDK or later

### Running the Application

1. Clone the repository
2. Navigate to the project directory
3. Run the following commands:

```bash
dotnet restore
dotnet build
dotnet run
```

The application will be available at `http://localhost:5000` or `https://localhost:5001`.

## Project Structure

- `Controllers/` - MVC controllers
- `Models/` - Data models and view models
- `Views/` - Razor views
- `wwwroot/` - Static files (CSS, JS, images)
- `Data/` - Database context and migrations
- `Services/` - Business logic services

## Testing

To run unit tests:

```bash
cd NASA.Missions.Tests
dotnet test
```
