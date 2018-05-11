using Discord.Commands;
using System.Threading.Tasks;

namespace NatssorBot.Modules
{
    public class Who : ModuleBase<SocketCommandContext>
    {
        [Command("who")]
        public async Task PingAsync()
        {
            await ReplyAsync("I am Ross, I'm shit at every game I play lul.");
        }
    }
}
