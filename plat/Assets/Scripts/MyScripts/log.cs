namespace Toon.Extend
{
    public static class Log
    {
        public static void show(this object msg)
        {
            UnityEngine.Debug.Log(
               $"<color=white>{msg}</color> <size=10>{File.caller_path()}: {File.caller_line_number()}</size>");
        }

        public static void warn(this object msg)
        {
            UnityEngine.Debug.LogWarning(
                $"<color=orange>{msg}</color> <size=10>{File.caller_path()}: {File.caller_line_number()}</size>");
        }

        public static void error(this object msg)
        {
            UnityEngine.Debug.LogError(
               $"<color=red>{msg}</color> <size=10>{File.caller_path()}: {File.caller_line_number()}</size>");
        }
    }
}
