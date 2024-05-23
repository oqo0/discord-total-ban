#pragma warning disable CS0618 // Type or member is obsolete

using Discord;
using Discord.Addons.Hosting;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Hosting;

namespace DiscordTotalBan.Configuration;

public static class DiscordHost
{
    public static IHostBuilder AddDiscordHost(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureDiscordHost((context, config) =>
        {
            config.SocketConfig = new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose,
                AlwaysDownloadUsers = true,
                MessageCacheSize = 200
            };
            config.Token = context.Configuration["Token"];
        })
        .UseCommandService((_, config) =>
        {
            config.DefaultRunMode = RunMode.Async;
            config.CaseSensitiveCommands = false;
        })
        .UseInteractionService((_, config) =>
        {
            config.LogLevel = LogSeverity.Info;
            config.UseCompiledLambda = true;
        })
        .ConfigureServices((_, services) =>
        {
            services.AddServices();
        });
        
        return hostBuilder;
    }
}