using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRChatCleanup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is irreversible and will delete all VRChat Cache / Temp data & Registry things\nPress any key to continue");
            Console.ReadLine();
            Console.WriteLine("Deleting VRChat Local Folder");
            DeleteFolder(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\VRChat");
            Console.WriteLine("Done\nDeleting VRChat Local Temp Folder");
            DeleteFolder(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\VRChat");
            Console.WriteLine("Done\nDeleting VRChat Local Low Folder");
            DeleteFolder(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "Low\\VRChat");
            Console.WriteLine("Done\nDeleting VRChat Roaming Folder");
            DeleteFolder(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\VRChat");
            Console.WriteLine("Done\nDeleting VRChat Unity Folder");
            DeleteFolder(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Temp\\DefaultCompany");
            Console.WriteLine("Done\nDeleting VRChat Unity Folder 2");
            DeleteFolder(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "Low\\DefaultCompany");
            Console.WriteLine("Done\nDeleting Registry Values");
            DeleteRegistry();
            Console.WriteLine("Done, Make sure to use your fav HWID spoofer and you should be fairly safe.");
            Console.ReadLine();
            

        }

        static private void DeleteFolder(string folder)
        {
            try
            {
                Directory.Delete(folder);
            } catch { }
        }

        static private void DeleteRegistry()
        {
            string keyName = @"Software\VRChat";
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true))
            {
                if (key != null)
                {
                    key.DeleteSubKey("VRChat");
                }
            }
        }
    }
}
