using Basket.Application.IoC;
using Basket.Infostructure.IoC;
using Basket.WebApi.Extensions.Options;
using Basket.WebApi.Extensions.Produsers;
using IdentityServer4.AccessTokenValidation;
using Microsoft.IdentityModel.Logging;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();

builder.Services.AddApplication();

IdentityModelEventSource.ShowPII = true;

builder.Services
    .AddApplicationDbContext(configuration)
    .AddRepositories();

builder.Services.AddProducers();

builder.Services
      .AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
      .AddIdentityServerAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme, options =>
      {
          options.Authority = configuration["AuthSettings:Authority"];
          options.ApiName = "Basket";
          options.RequireHttpsMetadata = false;
      });

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
