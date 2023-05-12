using System.Runtime.CompilerServices;

namespace Toon.Extend
{
    public static class File
    {
        public static string path(
            [CallerFilePath] string path = "",
            [CallerLineNumber] int line = 0
        ) => $"at {path}: {line}";
    }
}
