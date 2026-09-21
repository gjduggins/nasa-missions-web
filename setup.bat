@echo off

REM NASA Missions Website Setup Script

echo Setting up NASA Missions Website development environment...

REM Check if .NET 6.0 is installed
echo Checking for .NET 6.0 SDK...
dotnet --version >nul 2>&1
if %errorlevel% neq 0 (
    echo ERROR: .NET 6.0 SDK is not installed. Please install it from https://dotnet.microsoft.com/download/dotnet/6.0
    exit /b 1
)

for /f %%i in ('dotnet --version') do set DOTNET_VERSION=%%i
echo .NET version: %DOTNET_VERSION%

REM Restore dependencies
echo Restoring dependencies...
dotnet restore

REM Build the project
echo Building the project...
dotnet build

REM Run tests
echo Running tests...
dotnet test

echo Setup complete! You can now run the application with 'dotnet run --project NASA.Missions.Web'

pause