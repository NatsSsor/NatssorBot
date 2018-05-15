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
                Console.WriteLine("Got pinned message: " + message.Content);
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
                try
                {
                    messages.Remove(messages.Where(x => x.Id == message.Id).First());
                    Console.WriteLine("Attempted to remove pinned message from list of messages to remove: " + message.Content);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error removing pinned message: " + message.Content + " with exception " + ex.Message);
                }
               
            }

            await channel.DeleteMessagesAsync(messages);



        }
    }
}
