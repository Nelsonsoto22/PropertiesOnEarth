# PropertiesOnEarth
Web API for the Properties on earth System, where someone can create a user, consult and add properties.

## Nugget Package Used

- Cryptography

```sh
dotnet add package Konscious.Security.Cryptography.Argon2 --version 1.3.0
```

- Entity Framework
```sh
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.0-rc.2.22472.11
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.0-rc.2.22472.11
dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 7.0.0-rc.2.22472.11
```

- JWT Authentication
```sh
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 6.0.10
```


## Endpoints


|Verb|Entity|Endpoint|
|------|------|--------|
|GET|User|https://localhost:7064/api/user/register|
|POST|User|https://localhost:7064/api/user/login|
|GET|Category|https://localhost:7064/api/category|
|GET|Property|https://localhost:7064/api/property/List?categoryid=1|
|GET|Property|https://localhost:7064/api/property/Detail?propertyid=1|
|GET|Property|https://localhost:7064/api/property/Trending|
|GET|Property|https://localhost:7064/api/property/SearchAddress?address=test|
|POST|Property|https://localhost:7064/api/property|
|PUT|Property|https://localhost:7064/api/property/1|
|DELETE|Property|https://localhost:7064/api/property/1|

## License

MIT