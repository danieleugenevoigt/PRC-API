using Microsoft.EntityFrameworkCore;
using PRC.Core;
using PRC.Core.Interfaces;
using PRC.Core.Repositories;
using PRC.Api.Tasks;
using PRC.Api.Handlers;
using Mapster;
using PRC.Core.Transforms;
using PRC.Api.DTO_s;
using PRC.Core.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Load configuration files in order of precedence
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"Connection String: {connectionString}");

// Configure Entity Framework
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(connectionString);
    options.EnableSensitiveDataLogging(); // For debugging
    options.LogTo(Console.WriteLine, LogLevel.Information);
});

// Configure Mapster
TypeAdapterConfig<ProductTransform, ProductResponse>
    .NewConfig()
    .Map(dest => dest.Id, src => src.Id)
    .Map(dest => dest.Sku, src => src.Sku)
    .Map(dest => dest.SupplierCode, src => src.SupplierCode)
    .Map(dest => dest.Title, src => src.Title)
    .Map(dest => dest.Description, src => src.Description)
    .Map(dest => dest.Qty, src => src.Qty)
    .Map(dest => dest.Price, src => src.Price)
    .Map(dest => dest.IsActive, src => src.IsActive)
    .Map(dest => dest.CreatedAt, src => src.CreatedAt)
    .Map(dest => dest.UpdatedAt, src => src.UpdatedAt)
    .Map(dest => dest.Categories, src => src.Categories);

TypeAdapterConfig<CategoryTransform, CategoryResponse>
    .NewConfig()
    .Map(dest => dest.Id, src => src.Id)
    .Map(dest => dest.Name, src => src.Name)
    .Map(dest => dest.Slug, src => src.Slug);

TypeAdapterConfig<ProductImageTransform, ProductImageResponse>
    .NewConfig()
    .Map(dest => dest.Id, src => src.Id)
    .Map(dest => dest.ProductId, src => src.ProductId)
    .Map(dest => dest.ImageUrl, src => src.ImageUrl)
    .Map(dest => dest.AltText, src => src.AltText)
    .Map(dest => dest.SortOrder, src => src.SortOrder);

// Register dependency injection
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductTask>();
builder.Services.AddScoped<ProductHandler>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<CategoryTask>();
builder.Services.AddScoped<CategoryHandler>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            // This should be more restrictive in production, but is fine for development.
            // This must match the URL of your React app.
            policy.WithOrigins("http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

// Only use HTTPS redirection in production
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
