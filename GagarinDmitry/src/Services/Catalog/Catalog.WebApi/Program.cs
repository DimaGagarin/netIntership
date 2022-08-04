using Catalog.Application.IoC;
using Catalog.Infostructure.IoC;
using Catalog.WebApi.Extensions.Consumers;
using Catalog.WebApi.Extensions.Options;
using IdentityServer4.AccessTokenValidation;
using Microsoft.IdentityModel.Logging;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();

IdentityModelEventSource.ShowPII = true;

builder.Services
    .AddApplicationDbContext(configuration)
    .AddRepositories();

builder.Services.AddApplication();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddConsumers();

builder.Services
      .AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
      .AddIdentityServerAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme, options =>
      {
          options.Authority = configuration["AuthSettings:Authority"];
          options.ApiName = "Catalog";
          options.RequireHttpsMetadata = false;
      });

builder.Services.ConfigureOptions<SwaggerConfig>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.OAuthClientId(configuration["AuthSettings:AuthClientId"]);
        options.OAuthClientSecret(configuration["AuthSettings:AuthClientSecret"]);
    });
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
