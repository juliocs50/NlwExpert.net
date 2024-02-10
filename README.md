## Links

- [Visual Studio - Community](https://visualstudio.microsoft.com/pt-br/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false)
- [Postman - download](https://www.postman.com/downloads/) ou [Postman no navegador](https://identity.getpostman.com/signup?email=)
- [DB Browser for SQlite](https://sqlitebrowser.org/dl/)
- [Base64 Encoded](https://www.base64encode.org/pt/)

  ## Pacotes instalados com NuGet Packages

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Sqlite
- FluentAssertions
- Moq
- Bogus

 ## Arquivos

Arquivo do banco de dados:

[*Para abrir esse arquivo você precisa já ter instalado o DB Browser for SQlite na sua máquina!*](https://prod-files-secure.s3.us-west-2.amazonaws.com/08f749ff-d06d-49a8-a488-9846e081b224/b9de328b-cdd7-4d12-86fe-ee3f5f0e0fc9/leilaoDbNLW.db)

*Para abrir esse arquivo você precisa já ter instalado o DB Browser for SQlite na sua máquina!*

Código usado em Params.cs para configurar a autenticação direto no Swagger:

```csharp
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
                      Enter 'Bearer' [space] and then your token in the text input below;
                      Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});
```
