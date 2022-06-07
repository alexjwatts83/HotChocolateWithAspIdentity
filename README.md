# Hot Chocolate With ASP.NET Identity
A GraphQL app using Hot Chocolate, ASP.NET Identity and Entity Framework. Stuctured using clean architecture.

Essentially a copy of Clean Architecture but using GrapQL instead of a regular RESTful Api

## EF

### Add Migration
`dotnet ef migrations add Init --project src/HotChocolateWithAspIdentity.Infrastructure -s src/HotChocolateWithAspIdentity.GraphQL`

## Projects
This app consists of 4 Projects

## Domain
A simple project containing the simple entities used for the project

## GraphQL
`dotnet ef database update --project src/HotChocolateWithAspIdentity.Infrastructure -s src/HotChocolateWithAspIdentity.GraphQL`

## GraphQL Project
Is meant to be the main project which is a GraphQL project using Hot Chocolate

## v1
Use an interface implementing EF dbcontext

## v2
Use Mediatr