using BuildingBlocks.Exceptions.Handler;
using System.Reflection;

/// <summary>
/// Provides extension methods for configuring application services.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds and configures all application services required for the application to run.
    /// </summary>
    /// <param name="services">The service collection to add services to.</param>
    /// <param name="assembly">The assembly to scan for service implementations.</param>
    /// <returns>The modified service collection with all required services added.</returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, Assembly assembly)
    {
        //Carter
        services.AddCarter(configurator: c =>
        {
            // Specify the assembly containing your modules
            var modules = assembly.GetTypes()
                .Where(t => typeof(ICarterModule).IsAssignableFrom(t) && !t.IsAbstract)
                .ToArray();
            c.WithModules(modules);
        });

        //Fluent Validator
        services.AddValidatorsFromAssembly(assembly);

        //MediatR
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(assembly);
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            config.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });

        //Exception Handler
        services.AddExceptionHandler<CustomExceptionHandler>();

        //Webhook services
        services.AddSingleton<IWebhookQueue, WebhookQueue>();
        services.AddHostedService<WebhookBackgroundService>();

        return services;
    }
}