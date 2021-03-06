# Hot Chocolate With ASP.NET Identity
A GraphQL app using Hot Chocolate, ASP.NET Identity and Entity Framework. Stuctured using clean architecture.

Essentially a copy of Clean Architecture but using GrapQL instead of a regular RESTful Api

## EF
The app uses Entity Framework Core and uses an interface implementing EF `DbContext`.

### Add Migration
`dotnet ef migrations add Init --project src/HotChocolateWithAspIdentity.Infrastructure -s src/HotChocolateWithAspIdentity.GraphQL`

### GraphQL
`dotnet ef database update --project src/HotChocolateWithAspIdentity.Infrastructure -s src/HotChocolateWithAspIdentity.GraphQL`

## Projects
This app consists of 4 Projects.

### Domain
A simple project containing the simple entities used for the project.

### Application
A simple project containing the interfaces that the project will need and some additional models.

### Infrastructure
A project for the infrastructure of both Persistence and Identity. Essentially allot of code services.

#### Identity
Intended to use ASP.NET identity.

#### Persistence
Intended to use for EntityFramework.

### GraphQL Project
Is meant to be the main project which is a GraphQL project using Hot Chocolate.

## v1.0
Use an interface implementing EF `DbContext`.

### v1.1
Use Services.

## v2.0
Use Mediatr