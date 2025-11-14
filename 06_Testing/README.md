# Session 06 - testing 

This solution contains two projects:
1. TicketApp
> Console application with simple behavior simulating realistic service
2. TicketApp.Tests
> XUnit project that contains three unit tests for testing the behavior of the TicketApp functionality. 


They were created using the following `dotnet` commands:
```
cd O6_Testing
dotnet new sln -n 06_Testing

dotnet new console -n TicketApp
dotnet new xunit -n TicketApp.Tests

dotnet sln add TicketApp/TicketApp.csproj
dotnet sln add TicketApp.Tests/TicketApp.Tests.csproj

dotnet add TicketApp.Tests/TicketApp.Tests.csproj reference TicketApp/TicketApp.csproj
```

To run the tests:
```
cd 06_Testing/TestingApp.Tests
dotnet restore
dotnet build
dotnet test
```