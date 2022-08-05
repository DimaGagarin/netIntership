using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddJsonFile("Ocelot.Docker.json");

builder.Services.AddOcelot();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

 app.UseOcelot().Wait();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
