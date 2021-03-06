﻿using System.Linq;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using DiscordChatExporter.Cli.Commands.Base;
using DiscordChatExporter.Core.Utils.Extensions;

namespace DiscordChatExporter.Cli.Commands
{
    [Command("guilds", Description = "Get the list of accessible guilds.")]
    public class GetGuildsCommand : TokenCommandBase
    {
        public override async ValueTask ExecuteAsync(IConsole console)
        {
            var guilds = await Discord.GetUserGuildsAsync();

            foreach (var guild in guilds.OrderBy(g => g.Name))
            {
                await console.Output.WriteLineAsync(
                    $"{guild.Id} | {guild.Name}"
                );
            }
        }
    }
}