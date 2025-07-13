
using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Data;
using MyFirstAPI.Services; 
using MyFirstAPI.Repositories;
using MyFirstAPI.Middleware;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
  {
      options.SwaggerDoc("v1", new OpenApiInfo  // 定義 v1 文件
      {
          Title = "My First API - V1",  // API 標題
          Version = "v1",  // 版本號
          Description = "第一版 API"  // 描述
      });

      options.SwaggerDoc("v2", new OpenApiInfo  // 定義 v2 文件
      {
          Title = "My First API - V2",  // API 標題
          Version = "v2",  // 版本號
          Description = "第二版 API，新增分頁功能"  // 描述
      });
  });

builder.Services.AddApiVersioning(options => 
  {
      options.DefaultApiVersion = new ApiVersion(1, 0);  
      options.AssumeDefaultVersionWhenUnspecified = true; 
      options.ReportApiVersions = true; 
      options.ApiVersionReader = new UrlSegmentApiVersionReader(); 
  });

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";  
    options.SubstituteApiVersionInUrl = true;
});


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=MyFirstAPI.db"));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();
app.UseMiddleware<GEHmiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>  // 設定 Swagger UI
      {
          options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");  // V1 端點
          options.SwaggerEndpoint("/swagger/v2/swagger.json", "My API V2");  // V2 端點
      });
}

app.UseHttpsRedirection();
app.MapControllers();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
