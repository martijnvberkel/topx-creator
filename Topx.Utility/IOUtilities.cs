using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using Microsoft.Win32;

namespace Topx.Utility
{
    public interface IIOUtilities
    {
        void DeleteDirectoryAndContent(string path);
        void CreateDirectory(string targetDir);
        void Save(XElement element, string path);
        bool FileExists(string fullpath);
        void FileCopy(string source, string destination);
        bool DirectoryExists(string directory);

    }

    public class IOUtilities : IIOUtilities
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

        public static void ShowExplorer(string directory)
        {
            Process.Start("explorer.exe", directory);
        }

        public void CreateDirectory(string targetDir)
        {
            if (IsValidDirectoryName(targetDir))
                Directory.CreateDirectory(targetDir);
            else
                throw new Exception($"Directory {targetDir} bevat niet-toegestane karakters");
        }

        public void Save(XElement element, string path)
        {
            var filename = Path.GetFileName(path);
            if (IsValidFilename(filename))
                element.Save(path);
            else
                throw new Exception($"De filenaam is niet valide: {filename}");
        }

        public bool FileExists(string fullpath)
        {
            return File.Exists(fullpath);
        }

        public bool DirectoryExists(string directory)
        {
            return Directory.Exists(directory);
        }

        public void FileCopy(string source, string destination)
        {
            File.Copy(source, destination);
        }

        public void DeleteDirectoryAndContent(string path)
        {
            if (Directory.Exists(path))
            {
                //Delete all files from the Directory
                foreach (string file in Directory.GetFiles(path))
                {
                    File.Delete(file);
                }
                //Delete all child Directories
                foreach (string directory in Directory.GetDirectories(path))
                {
                    DeleteDirectoryAndContent(directory);
                }

                var deleted = false;
                var retry = 0;
                while (!deleted)
                {

                    try
                    {
                        //Delete a Directory
                        Directory.Delete(path);
                        deleted = true;
                    }
                    catch (Exception e)
                    {
                        retry += 1;
                        Thread.Sleep(100);
                        if (retry > 20)
                            throw new Exception($"Directory {path} kan niet worden verwijderd. Mogelijk is een bestand nog in gebruik");
                    }
                }
            }
        }

        public bool IsValidFilename(string fileName)
        {
            return !fileName.Any(f => Path.GetInvalidFileNameChars().Contains(f));
        }
        public bool IsValidDirectoryName(string dirName)
        {
            return !dirName.Any(f => Path.GetInvalidPathChars().Contains(f));
        }
    }
}
