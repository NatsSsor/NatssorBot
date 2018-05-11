using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discord.Commands;
using System.Threading.Tasks;
using NatssorBot.Helpers;
namespace NatssorBot.Modules
{
    public class Anime : ModuleBase<SocketCommandContext>
    {

        WebParser parser = new WebParser();

        [Command("Schedule")]
        public async Task PingAsync()
        {
            await ReplyAsync(parser.Schedule());
        }
    }
}
