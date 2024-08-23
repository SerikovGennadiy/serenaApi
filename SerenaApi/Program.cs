using Contracts;
using NLog;
using SerenaApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureCors();
builder.Services.ConfigureLogging();
builder.Services.ConfigureAutomapper();
builder.Services.ConfigureServiceManager();
builder.Services.AddControllers()
                .AddApplicationPart(typeof(SerenaApi.Presentation.AssemblyReference).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors();

var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureErrorHandler(logger);

app.MapControllers();

app.Run();


