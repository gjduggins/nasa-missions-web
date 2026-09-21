# NASA Missions Website

This is an ASP.NET Core web application for displaying information about NASA missions.

## Features
- View all NASA missions (current and past)
- Dedicated Historical Missions page with detailed descriptions
- Detailed mission information with launch dates and achievements
- Search functionality
- Admin panel for managing mission data
- Responsive design using Bootstrap 5
- Comprehensive unit test coverage

## Technologies Used
- ASP.NET Core MVC
- Entity Framework Core
- Bootstrap 5
- SQLite database
- xUnit for testing
- Moq for mocking in tests

## Getting Started

### Prerequisites
- .NET 6.0 SDK or later
- Visual Studio 2022 or later (optional)
- Git

### Running the Application

1. Clone the repository:
   ```bash
   git clone https://github.com/gjduggins/nasa-missions-web.git
   ```

2. Navigate to the project directory:
   ```bash
   cd nasa-missions-web
   ```

3. Restore dependencies:
   ```bash
   dotnet restore
   ```

4. Build the project:
   ```bash
   dotnet build
   ```

5. Run database migrations (optional, as the app uses in-memory data initially):
   ```bash
   cd NASA.Missions.Web
   dotnet ef database update
   ```

6. Run the application:
   ```bash
   dotnet run
   ```

The application will be available at `http://localhost:5252` or `https://localhost:7072`.

## Project Structure

```
nasa-missions-web/
├── NASA.Missions.Web/
│   ├── Controllers/          # MVC controllers
│   ├── Data/                 # Database context and migrations
│   ├── Models/               # Data models and view models
│   ├── Services/             # Business logic services
│   ├── Views/                # Razor views
│   ├── wwwroot/              # Static files (CSS, JS, images)
│   ├── Program.cs            # Application entry point
│   └── NASA.Missions.Web.csproj
├── NASA.Missions.Tests/
│   ├── Services/             # Service unit tests
│   ├── Controllers/          # Controller unit tests
│   └── NASA.Missions.Tests.csproj
└── README.md
```

## Database

The application uses SQLite for data persistence. Seed data is included for demonstration purposes with historically significant missions:

1. **Apollo 11** - First crewed mission to land on the Moon (1969)
2. **Voyager 1** - Deep space probe that entered interstellar space (1977-Present)
3. **Hubble Space Telescope** - Revolutionary space-based observatory (1990-Present)
4. **Mars Pathfinder** - First successful Mars rover mission (1996-1997)
5. **Cassini-Huygens** - Saturn exploration mission (1997-2017)
6. **Mars Rover Perseverance** - Current Mars exploration mission (2020-Present)

Each mission includes detailed descriptions of their achievements and significance.

## Testing

To run unit tests:

```bash
cd NASA.Missions.Tests
dotnet test
```

The test suite includes:
- Service layer tests using in-memory database
- Controller tests using Moq for dependency injection
- Tests for all controller actions including the new Historical missions page

## Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- NASA for providing inspiration for this project
- Microsoft for the ASP.NET Core framework
- Bootstrap for the responsive design framework