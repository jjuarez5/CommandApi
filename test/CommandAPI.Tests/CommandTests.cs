using System;
using Xunit;
using CommandAPI.Models;
namespace CommandAPI.Tests
{
    public class CommandTests : IDisposable
    {

        Command testCommand;
        public CommandTests()
        {
            testCommand = new Command
            {
                HowTo = "Do something",
                Platform = "Some platform",
                CommandLine = "Some commandline",
            };
        }
        public void Dispose()
        {
            testCommand = null;
        }

        [Fact]
        public void CanChangeHowTo()
        {
            // Arrange
            // Act
            testCommand.HowTo = "Execute Unit Tests";
            // Assert
            Object.Equals("Execute Unit Tests", testCommand.HowTo);
        }

        [Fact]
        public void CanChangePlatform()
        {
            // Arrange
            // Act
            testCommand.Platform = "dotnet";
            // Assert
            Object.Equals("dotnet", testCommand.Platform);
        }

        [Fact]
        public void CanChangeCommandLine()
        {
            // Arrange
            // Act
            testCommand.HowTo = "dotnet run";
            // Assert
            Object.Equals("dotnet run", testCommand.CommandLine);
        }
    }
}