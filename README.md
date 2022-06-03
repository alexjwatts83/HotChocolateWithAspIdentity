# Hot Chocolate With ASP.NET Identity
A GraphQL app using Hot Chocolate, ASP.NET Identity and Entity Framework. Stuctured using clean architecture.

Essentially a copy of Clean Architecture but using GrapQL instead of a regular RESTful Api

## EF
`dotnet ef migrations add Init --project src/HotChocolateWithAspIdentity.Infrastructure -s src/HotChocolateWithAspIdentity.GraphQL`

## v1
Use an interface implementing EF dbcontext

## v2
Use Mediatr