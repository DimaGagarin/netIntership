using Identity.Application.IoC;
using Identity.Infostructure.IoC;
using Identity.WebApi.Extensions.Options;
using Identity.WebApi.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build();

builder.Services.ConfigureLogs(configuration);
builder.Host.UseSerilog();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddApplicationDbContext()
    .AddIdentityService(builder.Configuration);

builder.Services.AddApplication();

builder.Services.ConfigureOptions<SwaggerConfig>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseIdentityServer();

await app.InitializeDatabase();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
