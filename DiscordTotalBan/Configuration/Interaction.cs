using Discord;
using Discord.Addons.ChainHandlers;
using Discord.Addons.ChainHandlers.Default;
using Discord.Interactions;
using Microsoft.Extensions.DependencyInjection;

namespace DiscordTotalBan.Configuration;

public static class Interaction
{
    public static IServiceCollection AddInteractionHandler(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddInteractionHandler(options =>
        {
            options.UseChainHandler(handlerOptions =>
            {
                handlerOptions
                    .Add<ErrorChainHandler>()
                    .Add<ProblemChainHandler>();
            });

            options.UseFinalHandler(ConfigureFinalHandler);
            options.ConfigureInteractionService(ConfigureCommands);
        });

        return serviceCollection;
    }

    private static async void ConfigureFinalHandler(IInteractionContext interactionContext)
    {
        await interactionContext.Interaction.RespondAsync(":x: Something went wrong", ephemeral: true);
    }

    private static async void ConfigureCommands(InteractionService interactionService)
    {
        await interactionService.AddModulesGloballyAsync(true, Array.Empty<Discord.Interactions.ModuleInfo>());
        await interactionService.RegisterCommandsGloballyAsync();
    }
}