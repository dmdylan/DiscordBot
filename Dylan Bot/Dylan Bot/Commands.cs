using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;
using System.IO;
using System;
using DSharpPlus.Net;

namespace Dylan_Bot
{
    class Commands
    {

        [Command("hi")]
        public async Task Hi(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync($"👋 Hi, {ctx.User.Mention}!");
        }
        
        [Command("grats")]
        public async Task Congratulations(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync("https://tenor.com/uEWd.gif");          
        }

        [Command("yes")]
        public async Task YesYesYes(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();
            await ctx.RespondAsync("https://i.imgur.com/Qgl3Q2K.gif");
        }

        /*
        [Command("frank")]
        public async Task FrankWipedUs(CommandContext command)
        {
            frankWipeCounter++;            
            await command.RespondAsync($"Frank has caused {frankWipeCounter} wipes 💩");
        }

        [Command("wipe")]
        public async Task WeWiped(CommandContext command)
        {
            await command.RespondAsync($"The group has wiped {wipeCounter} times");
        }
        */
    }
}
