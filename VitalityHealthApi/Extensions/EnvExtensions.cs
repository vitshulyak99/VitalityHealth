using System.Reflection.Metadata.Ecma335;

namespace VitalityHealthApi.Extensions
{
    public static class EnvExtensions
    {
        private const string ASPNET_DB_NAME = "ASPNET_DB_NAME";
        private const string ASPNET_DB_PASSWORD = "ASPNET_DB_PASSWORD";
        private const string ASPNET_DB_PORT = "ASPNET_DB_PORT";
        private const string ASPNET_DB_USER = "ASPNET_DB_USER";
        private const string ASPNET_DB_HOST = "ASPNET_DB_HOST";
        public static string? GetDbConnectionString(IConfiguration configuration)
        {
            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            if (Environment.GetEnvironmentVariable(ASPNET_DB_HOST) is { } host 
                && Environment.GetEnvironmentVariable(ASPNET_DB_NAME) is { } name
                && Environment.GetEnvironmentVariable(ASPNET_DB_PASSWORD) is { } pass
                && Environment.GetEnvironmentVariable(ASPNET_DB_USER) is { } user
                && Environment.GetEnvironmentVariable(ASPNET_DB_PORT) is { } port
                && configuration.GetConnectionString("Docker") is { } connectionString)
            {
                return string.Format(connectionString, user, pass, host, port, name);
            }

            return configuration.GetConnectionString("Default");
        }
    }
}
