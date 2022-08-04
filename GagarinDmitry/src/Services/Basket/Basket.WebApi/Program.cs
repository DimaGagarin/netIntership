using Basket.Application.IoC;
using Basket.Infostructure.IoC;
using Basket.WebApi.Extensions.Options;
using Basket.WebApi.Extensions.Produsers;
using IdentityServer4.AccessTokenValidation;
using Microsoft.IdentityModel.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();

IdentityModelEventSource.ShowPII = true;

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddRepositories();

// Add services to the container.

builder.Services.AddProducers();

builder.Services
      .AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
      .AddIdentityServerAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme, options =>
      {
          options.Authority = builder.Configuration["AuthSettings:Authority"];
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
        options.OAuthClientId("BasketClient");
        options.OAuthClientSecret("70dc89ef-d09e-4a6d-94ba-bcd66a723e92");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
