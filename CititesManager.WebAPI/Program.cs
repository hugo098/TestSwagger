using CititesManager.WebAPI.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ProducesAttribute("application/json"));
    options.Filters.Add(new ConsumesAttribute("application/json"));
})
.AddXmlSerializerFormatters();

builder.Services.AddApiVersioning(config =>
{
    config.ApiVersionReader = new UrlSegmentApiVersionReader();
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

// Swagger
builder.Services.AddEndpointsApiExplorer(); // Generates description for all enpoints
builder.Services.AddSwaggerGen(options =>
{
    options.IncludeXmlComments(
        //Path.Combine(AppContext.BaseDirectory, "api.xml"));
        Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));

    options.SwaggerDoc("v1", new OpenApiInfo() { Title = "Cities Web API", Version = "1.0" });
    options.SwaggerDoc("v2", new OpenApiInfo() { Title = "Cities Web API", Version = "2.0" });

}); // Generates OpenAPI specification

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHsts();

app.UseHttpsRedirection();

app.UseSwagger(); // creates endpoint for swagger.json
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "1.0");
    options.SwaggerEndpoint("/swagger/v2/swagger.json", "2.0");

}); // creates swagger UI for testing all Web API endpoints / action methods

app.UseAuthorization();

app.MapControllers();

app.Run();
