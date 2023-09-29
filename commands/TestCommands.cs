using System.Net.Sockets;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace SaulGoodman.commands;

public class TestCommands : BaseCommandModule
{
    [Command("add ")]
    public async Task Add(CommandContext ctx, int a, int b)
    {
        int addition = a + b;
        await ctx.Channel.SendMessageAsync(addition.ToString());
    }
}