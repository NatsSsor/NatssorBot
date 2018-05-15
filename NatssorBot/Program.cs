using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace NatssorBot
{
    class Program
    {
        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;

        

        static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();
        
        public async Task RunBotAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();

            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();

            _client.Log += LogHandler;

            await RegisterCommandsAsync();
            await _client.LoginAsync(TokenType.Bot, Properties.Settings.Default.APIKey);
            await _client.StartAsync();

            await _client.SetStatusAsync(UserStatus.Online);
            await _client.SetGameAsync("Dota 2");

            await Task.Delay(-1);
        }

        private Task LogHandler(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.FromResult(0);
        }

        public async Task RegisterCommandsAsync()
        {
            _client.MessageReceived += CommandReceivedHandler;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        private async Task CommandReceivedHandler(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            if (message == null || message.Author.IsBot) return;

            var argPos = 0;
            if (message.HasStringPrefix("Tanya!", ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                var context = new SocketCommandContext(_client, message);
                var result = await _commands.ExecuteAsync(context, argPos, _services);
                if (!result.IsSuccess)
                    Console.WriteLine(result.ErrorReason);
            }
        }
    }
}
