#!/bin/bash

# NASA Missions Website Setup Script

echo "Setting up NASA Missions Website development environment..."

# Check if .NET 6.0 is installed
echo "Checking for .NET 6.0 SDK..."
if ! command -v dotnet &> /dev/null
then
    echo "ERROR: .NET 6.0 SDK is not installed. Please install it from https://dotnet.microsoft.com/download/dotnet/6.0"
    exit 1
fi

DOTNET_VERSION=$(dotnet --version)
echo ".NET version: $DOTNET_VERSION"

# Restore dependencies
echo "Restoring dependencies..."
dotnet restore

# Build the project
echo "Building the project..."
dotnet build

# Run tests
echo "Running tests..."
dotnet test

echo "Setup complete! You can now run the application with 'dotnet run --project NASA.Missions.Web'