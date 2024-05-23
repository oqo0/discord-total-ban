using DiscordTotalBan.ClientServices;
using Microsoft.Extensions.DependencyInjection;

namespace DiscordTotalBan.Configuration;

public static class Services
{
    public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHostedService<BanEverywhereClientService>();
        
        return serviceCollection;
    }
}