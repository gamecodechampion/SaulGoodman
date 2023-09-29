using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using SaulGoodman.commands;

namespace SaulGoodman
{
    public class Program
    {
        private static DiscordClient bot { get; set; }
        private static CommandsNextExtension commands { get; set; }
        static async Task Main(string[] args)
        {
            var jsonReader = new JSONReader();
            await jsonReader.ReadJson();

            var discordConfig = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = jsonReader.token,
                TokenType = TokenType.Bot,
                AutoReconnect = true
            };

            bot = new DiscordClient(discordConfig);
            bot.Ready += BotOnReady;

            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { jsonReader.prefix },
                EnableMentionPrefix = true,
                CaseSensitive = false,
                EnableDefaultHelp = false
            };

            commands = bot.UseCommandsNext(commandsConfig);

            commands.RegisteredCommands<TestCommands>();

            await bot.ConnectAsync();
            await Task.Delay(-1);
        }

        private static Task BotOnReady(DiscordClient sender, ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}

