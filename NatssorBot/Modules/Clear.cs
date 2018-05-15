using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatssorBot.Modules
{

   public class Clear : ModuleBase<Discord.Commands.SocketCommandContext>
    {
        [Command("clear")]
        public async Task PingAsync()
        {
            var context = this.Context.Channel.Name;

            Discord.ITextChannel channel = (Discord.ITextChannel)this.Context.Channel;

            //List<Discord.IMessage> messages = new List<Discord.IMessage>();
            //List<Discord.IMessage> pinnedMessages = new List<Discord.IMessage>();

           var temppinnedMessages = await channel.GetPinnedMessagesAsync();
            var pinnedMessages = new List<Discord.IMessage>();
            foreach(var message in temppinnedMessages)
            {
                pinnedMessages.Add(message);
            }
            //List<Discord.IMessage> messages = new List<Discord.IMessage>();
            List<Discord.IMessage> messages = new List<Discord.IMessage>();
            var asyncmessages = channel.GetMessagesAsync(100000).ToEnumerable();
           foreach(var message in asyncmessages)
            {
                foreach(var m in message)
                {
                    messages.Add(m);
                }
            }
            
            foreach (var message in pinnedMessages)
            {
                messages.Remove(message);
            }

            await channel.DeleteMessagesAsync(messages);



        }
    }
}
