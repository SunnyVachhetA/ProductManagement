using ProductManagement.Service;
using ProductManagementPS.Extensions;
using ProductManagementPS.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureSwagger(); //Configure swagger

builder.Services.SetRequestBodySize(); //Set request body size limit

builder.Services.ConfigureCors(); //Setting origin to access API

builder.Services.ConnectDatabase(builder.Configuration); //Connect with database using appsettings.json ConnectionString

builder.Services.RegisterServices(); //Register Services and Repository

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
