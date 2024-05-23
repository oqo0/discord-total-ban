using Discord.Addons.Hosting;
using Discord.Addons.Hosting.Util;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;

namespace DiscordTotalBan.ClientServices;

public class BanEverywhereClientService : DiscordClientService
{
    public BanEverywhereClientService(
        DiscordSocketClient client,
        ILogger<DiscordClientService> logger) : base(client, logger) { }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await Client.WaitForReadyAsync(cancellationToken);
        Client.UserBanned += HandleUserBanned;
    }

    private async Task HandleUserBanned(SocketUser socketUser, SocketGuild socketGuild)
    {
        foreach (var guild in Client.Guilds)
        {
            await guild.AddBanAsync(socketUser);
        }
    }
}