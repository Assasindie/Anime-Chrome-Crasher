using Discord.Webhook;

namespace Anime_Chrome_Crasher
{
    class WeebHook
    {
        public static void SendMessage(string message)
        {
            DiscordWebhookClient discord = new DiscordWebhookClient(534522813999712223, "HL3z8PCYFgJeqOZjB5BEFCjivcqeX-4ZBnF4headlsA-BRhI8wv-fmmy_WF7Ndmlke");
            discord.SendMessageAsync(message);
        }
    }
}