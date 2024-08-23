using NLog;
using Contracts;
using LoggerService;
using Service.Contracts;
using Service;

namespace SerenaApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(setup =>
            {
                setup.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

        public static void ConfigureLogging(this IServiceCollection services)
        {
            var configPath = string.Concat(Directory.GetCurrentDirectory(), "/nlog.config");
            LogManager.Setup().LoadConfigurationFromFile(configPath);

            services.AddSingleton<ILoggerService, LoggerManager>();
        }

        public static void ConfigureAutomapper(this IServiceCollection services) =>
            services.AddAutoMapper(typeof(Program));

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();
    }
}
