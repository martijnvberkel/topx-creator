using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace Topx.Utility
{
    public class IOUtilities
    {

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetDiskFreeSpaceEx(string lpDirectoryName, out ulong lpFreeBytesAvailable, out ulong lpTotalNumberOfBytes, out ulong lpTotalNumberOfFreeBytes);

        public static ulong DiskspaceBytes(string dir)
        {
            ulong freeBytes;
            bool success = GetDiskFreeSpaceEx(dir, out freeBytes, out _, out _);
            if (!success)
                throw new System.ComponentModel.Win32Exception();
            return freeBytes;

        }

        public static string GetJavaInstallationPath()
        {
            var environmentPath = Environment.GetEnvironmentVariable("JAVA_HOME");
            if (!string.IsNullOrEmpty(environmentPath))
            {
                return environmentPath;
            }

            var javaKey = "SOFTWARE\\JavaSoft\\Java Runtime Environmentx\\";
           
            using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            using (var rk = hklm.OpenSubKey(javaKey))
            {
                string currentVersion = rk?.GetValue("CurrentVersion").ToString();
                using (Microsoft.Win32.RegistryKey key = rk?.OpenSubKey(currentVersion))
                {
                    return key?.GetValue("JavaHome").ToString();
                }
            }
        }
    }
}
