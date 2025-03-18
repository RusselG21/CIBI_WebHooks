using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

/// <summary>
/// Provides extension methods for configuring common webhook services.
/// </summary>
public static class WebhookDependencyInjection
{
	/// <summary>
	/// Adds common webhook services to the service collection.
	/// </summary>
	/// <param name="services">The service collection to add services to.</param>
	/// <returns>The modified service collection with webhook services added.</returns>
	public static IServiceCollection AddWebhookServices(this IServiceCollection services)
	{
		// Add basic webhook services here
		// This is a base implementation that specific webhook modules can extend

		return services;
	}
}
