using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;

namespace Identity.WebApi.Extensions.Options
{
    /// <summary>
    /// Provides LoggerConfiguration.
    /// </summary>
    public static class LoggerConfiguration
    {
        /// <inheritdoc/>
        public static IServiceCollection ConfigureLogs(this IServiceCollection services, IConfigurationRoot configuration)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            Log.Logger = new Serilog.LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .WriteTo.Debug()
                .WriteTo.Console()
                .WriteTo.Elasticsearch(ConfigureELS(configuration, env))
                .CreateLogger();

            return services;
        }

        /// <inheritdoc/>
        public static ElasticsearchSinkOptions ConfigureELS(IConfigurationRoot configuration, string? env)
        {
            return new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"]))
            {
                AutoRegisterTemplate = true,
                IndexFormat = $"{Assembly.GetExecutingAssembly()?.GetName()?.Name?.ToLower()}-{env?.ToLower().Replace(".", ",")}-{DateTime.UtcNow:yyyy-MM}"
            };
        }
    }
}
