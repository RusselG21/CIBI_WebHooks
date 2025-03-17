using BuildingBlocks.Exceptions.Handler;
using System.Reflection;

public static class DependencyInjection
{
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