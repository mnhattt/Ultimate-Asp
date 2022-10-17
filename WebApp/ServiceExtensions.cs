using Contracts;
using LoggerService;

namespace WebApp;

public static class ServiceExtensions
{
    public static void ConfigLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerManager, LoggerManager>();
}