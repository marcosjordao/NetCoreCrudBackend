# .Net REST API - Backend

Simple CRUD backend application.

It was written thinking about:
 - OOP - Object oriented programming
 - DDD - Domain driven design
 - TDD - Test driven development
 - SOLID
 
## Coded with:
 * **[.NET Core (v 2.2)](https://dotnet.microsoft.com)**
 * [Entity Framework Core](https://docs.microsoft.com/pt-br/ef/core/)
 
 * [FluentValidation](https://fluentvalidation.net/)
 * [xUnit](https://xunit.github.io/)
 * [Swashbuckle Swagger](https://swagger.io/)
 
## How to run
```
dotnet restore
cd Crud.Infrastructure
dotnet ef database update
cd ..\Crud.API
dotnet run
```
