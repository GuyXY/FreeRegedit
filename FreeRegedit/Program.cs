using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeRegedit
{
    class Program
    {

        private static byte counter = 0;

        static void Main(string[] args)
        {
            string keyPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options";
            RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath, true);
            DeleteValue(OpenSubKey(key, "regedit.exe"));
            DeleteValue(OpenSubKey(key, "reg.exe"));
            Console.WriteLine(counter + " entries were removed!");
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        private static RegistryKey OpenSubKey(RegistryKey key, string subkey)
        {
            return key.OpenSubKey(subkey, true);
        }

        private static void DeleteValue(RegistryKey key)
        {
            if (key != null && key.GetValue("Debugger") != null)
            {
                key.DeleteValue("Debugger");
                counter++;
            }
        }

    }
}
