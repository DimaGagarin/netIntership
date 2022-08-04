using Catalog.Application.IoC;
using Catalog.Infostructure.IoC;
using Catalog.WebApi.Extensions.Consumers;
using Catalog.WebApi.Extensions.Options;
using IdentityServer4.AccessTokenValidation;
using Microsoft.IdentityModel.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplication();

IdentityModelEventSource.ShowPII = true;

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddRepositories();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddConsumers();

builder.Services
      .AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
      .AddIdentityServerAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme, options =>
      {
          options.Authority = builder.Configuration["AuthSettings:Authority"];
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
        options.OAuthClientId("CatalogClient");
        options.OAuthClientSecret("08c0f7a5-5d48-4041-a2f6-95134be09a94");
    });
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
