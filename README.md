# Backend - .Net REST API

Base backend application with a simple CRUD.

It was written thinking about:
 - OOP - Object oriented programming
 - DDD - Domain driven design
 - TDD - Test driven development

## Coded with:
 - [.NET Core (v 2.2)](https://dotnet.microsoft.com)
 - [Entity Framework Core](https://docs.microsoft.com/pt-br/ef/core/)

 - [xUnit](https://xunit.github.io/)
 - [FluentValidation](https://fluentvalidation.net/)

## How to run
In the root directory:
```
dotnet restore
cd Crud.Infrastructure
dotnet ef database update
cd ..\Crud.API
dotnet run
```