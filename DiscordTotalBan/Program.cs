using DiscordTotalBan.Configuration;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args);

host.AddDiscordHost();

await host
    .Build()
    .RunAsync();