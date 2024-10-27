using Microsoft.EntityFrameworkCore;
using radlab4._0.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add Swagger services to generate API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext for TodoItems API
var todoConnectionString = builder.Configuration.GetConnectionString("TodoDatabase") ?? "Data Source=todo.db";
builder.Services.AddSqlite<TodoDbContext>(todoConnectionString);

// Add DbContext for Advertisements API
var adConnectionString = builder.Configuration.GetConnectionString("AdDatabase") ?? "Data Source=ads.db";
builder.Services.AddSqlite<AdDbContext>(adConnectionString);

var app = builder.Build();

// Seed the databases if necessary
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        SeedData.Initialize(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    // Enable Swagger for API documentation in Development environment
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        // Making Swagger available at both /swagger and the root (index.html)
        c.RoutePrefix = string.Empty; // Access Swagger at the root URL (localhost:5040/index.html)
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers(); // Map controller routes

app.Run();