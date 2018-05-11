using Discord.Commands;
using System.Threading.Tasks;

namespace NatssorBot.Modules
{
    public class Who : ModuleBase<SocketCommandContext>
    {
        [Command("who")]
        public async Task PingAsync()
        {
            await ReplyAsync(@"http://www.crunchyroll.com/saga-of-tanya-the-evil");
        }
    }
}
