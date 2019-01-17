using Microsoft.Win32;
using System;
using System.Diagnostics;

namespace Remove_Anime_Chrome_Crasher
{
    class Program
    {
        static void Main(string[] args)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                key.DeleteValue("My Program", false);
            }
            Console.WriteLine("Removed program from startup");
            foreach (var process in Process.GetProcessesByName("WindowsFormsApp6"))
            {
                try
                {
                    try
                    {
                        process.Kill();
                    }
                    catch (InvalidOperationException)
                    {

                    }
                }
                catch (System.ComponentModel.Win32Exception)
                {

                }
            }
            Console.WriteLine("Killed all processes of the program.");
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }
    }
}
