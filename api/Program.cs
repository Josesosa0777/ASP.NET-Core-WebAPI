using api.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, _) =>
    {
        document.Info = new()
        {
            Title = "Maturity Metrics API",
            Version = "v1",
            Description = """
                Modern API for managing for Maturity Metrics.
                Supports JSON and XML responses.
                Rate limited to 1000 requests per hour.
                """,
            Contact = new()
            {
                Name = "API Support",
                Email = "jose.sosa@bendix.com",
                Url = new Uri("https://api.example.com/support")
            }
        };
        return Task.CompletedTask;
    });
});

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "/openapi/v1.json";
        options.DocumentTitle = "Maturity Metrics";
    });
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("Maturity Metrics API")
            .WithTheme(ScalarTheme.Mars)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
