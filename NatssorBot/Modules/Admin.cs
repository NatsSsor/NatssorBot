using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NatssorBot.Modules
{
    public class Admin : ModuleBase<Discord.Commands.SocketCommandContext>
    {

        [Command("AvailableColours")]
        public async Task PingAsync()
        {
            var colorlist = new StringBuilder();
            colorlist.Append("Available colours are: ");
            var colors = Enum.GetValues(typeof(DiscordColors));
            for (int i = 0; i < colors.Length;i++)
            {
                colorlist.Append(colors.GetValue(i));
                colorlist.Append(", ");
            }
            colorlist.Append(" or supply an rgb value seperated by commas e.g. 100,100,100");
           await ReplyAsync(colorlist.ToString());
        }

        [Command("AddRole")]
        public async Task PingAsync(string rolename, string color)
        {
           var context = this.Context.User;
            Discord.Color col;

            if (color.Contains(","))
            {
                var rgb = color.Split(',');
                if(rgb.Count() != 3)
                {
                    await ReplyAsync("Invalid number of parameters");
                    return;
                }
                else
                {
                     col = new Discord.Color(Convert.ToInt32(rgb[0]), Convert.ToInt32(rgb[1]), Convert.ToInt32(rgb[2]));
                }
                
            }
            else if(color != string.Empty)
            {
                col = new Discord.Color();
                FieldInfo[] fields = col.GetType().GetFields();

                var field = fields.Where(x => x.Name == color).First();
               col =(Discord.Color)field.GetValue(null);
                

               // Discord.Color.//GetType().GetField(color);
            }
            else
            {
              await  this.Context.Guild.CreateRoleAsync(rolename);
                return;
            }
            //Discord.Color col = new Discord.Color() 
           await this.Context.Guild.CreateRoleAsync(rolename, null, col);
        }

        enum DiscordColors
        {
            Default,
            //
            // Summary:
            //     Gets the darker grey color value
            DarkerGrey,
            //
            // Summary:
            //     Gets the dark grey color value
            DarkGrey,
            //
            // Summary:
            //     Gets the lighter grey color value
            LighterGrey,
            //
            // Summary:
            //     Gets the light grey color value
            LightGrey,
            //
            // Summary:
            //     Gets the dark red color value
            DarkRed,
            //
            // Summary:
            //     Gets the red color value
            Red,
            //
            // Summary:
            //     Gets the orange color value
            Orange,
            //
            // Summary:
            //     Gets the light orange color value
            LightOrange,
            //
            // Summary:
            //     Gets the gold color value
            Gold,
            //
            // Summary:
            //     Gets the dark orange color value
            DarkOrange,
            //
            // Summary:
            //     Gets the magenta color value
            Magenta,
            //
            // Summary:
            //     Gets the dark magenta color value
            DarkMagenta,
            //
            // Summary:
            //     Gets the dark teal color value
            DarkTeal,
            //
            // Summary:
            //     Gets the green color value
            Green,
            //
            // Summary:
            //     Gets the dark green color value
            DarkGreen,
            //
            // Summary:
            //     Gets the teal color value
            Teal,
            //
            // Summary:
            //     Gets the dark blue color value
            DarkBlue,
            //
            // Summary:
            //     Gets the purple color value
            Purple,
            //
            // Summary:
            //     Gets the dark purple color value
            DarkPurple,
        //
        // Summary:
        //     Gets the blue color value
            Blue
        }
    }
}
