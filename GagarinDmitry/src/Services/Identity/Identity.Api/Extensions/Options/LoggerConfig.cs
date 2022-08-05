using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;

namespace Identity.WebApi.Extensions.Options
{
    /// <summary>
    /// Provides LoggerConfiguration.
    /// </summary>
    public static class LoggerConfig
    {
        /// <summary>
        /// Method for logging configuration
        /// </summary>
        /// <param name="configuration">Application configuration</param>
        public static void ConfigureLogs(IConfigurationRoot configuration)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .WriteTo.Debug()
                .WriteTo.Console()
                .WriteTo.Elasticsearch(ConfigureELS(configuration, env))
                .CreateLogger();
        }

        /// <summary>
        /// Method for Elasticsearch configuration
        /// </summary>
        /// <param name="configuration">Application configuration</param>
        /// <param name="env">Current environment</param>
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
