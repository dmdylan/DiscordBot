using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.Net.WebSocket;
using System.Threading.Tasks;
using DSharpPlus.Entities;

namespace Dylan_Bot
{
    public class Program
    {
        static DiscordClient discord;
        static CommandsNextModule commands;
        //static InteractivityModule interactivity;

        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = " ",
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });

            discord.SetWebSocketClient<WebSocket4NetCoreClient>();          

            discord.MessageCreated += async e =>
            {
                if (e.Message.Content.ToLower().StartsWith("ping"))
                    await e.Message.RespondAsync("pong!");
            };

            discord.MessageCreated += async e =>
            {
                if (!(e.Message.Author.IsBot) && e.Message.Content.ToLower().Contains("hackerman"))
                    await e.Message.RespondAsync("You mean HACKERMAN! " +
                        "https://gph.is/1JSLT6V");
            };

            discord.MessageCreated += async e =>
            {
                var emoji = DiscordEmoji.FromName(discord, ":thumbsup:");
                if (e.Message.Content.Contains(emoji) && !(e.Message.Author.IsBot))
                    await e.Message.RespondAsync(emoji);
            };

            discord.MessageCreated += async e =>
            {
                var emoji = DiscordEmoji.FromGuildEmote(discord, 409841266436734976);
                if (e.Message.Content.Contains(emoji) && !(e.Message.Author.IsBot))
                {
                    await e.Message.RespondAsync(emoji);
                    await e.Message.CreateReactionAsync(emoji);
                }                  
                else if (e.Message.Content.Contains(emoji))
                {
                    await e.Message.CreateReactionAsync(emoji);
                }                   
            };

            discord.MessageCreated += async e =>
            {              
                if (e.Message.Content.ToLower().Contains("thanks bot"))
                    await e.Message.RespondAsync("👍");
            };

            commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = "d!"
            });

            commands.RegisterCommands<Commands>();

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
