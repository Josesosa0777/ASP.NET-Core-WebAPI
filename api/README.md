# 
To execute the project, execute:

```
dotnet watch run  # dotnet run --launch-profile https
```


for migrations:
dotnet ef migrations add init
dotnet ef database update


For initialize new webapi project:
dotnet new webapi -o api 
dotnet dev-certs https --trust


Installations:
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package NSwag.AspNetCore
dotnet add package Scalar.AspNetCore --version 2.0.30
dotnet tool install --global dotnet-ef
dotnet ef --version


# Based on:
https://youtu.be/qBTe6uHJS_Y?si=ZIUUahUIPIgYqM9a

