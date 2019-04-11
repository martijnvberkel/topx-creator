using System;
using System.Runtime.InteropServices;

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
    }
}
