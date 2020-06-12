using System;
using System.Runtime.InteropServices;

namespace AddCitaviProjectToRecentList
{
    public class Shell32Api
    {
        public enum ShellAddToRecentDocsFlags
        {
            Pidl = 0x001,
            Path = 0x002,
        }

        [DllImport("shell32.dll", CharSet = CharSet.Ansi)]
        public static extern void SHAddToRecentDocs(ShellAddToRecentDocsFlags flag, string path);

        [DllImport("shell32.dll")]
        public static extern void SHAddToRecentDocs(ShellAddToRecentDocsFlags flag, IntPtr pidl);

        public static void AddToRecentDocs(string path) => SHAddToRecentDocs(ShellAddToRecentDocsFlags.Path, path);
    }
}
