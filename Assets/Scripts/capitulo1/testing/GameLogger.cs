using UnityEngine;
using System.IO;
using System.Text;

public static class GameLogger
{
    private static string folderPath => Path.Combine(Application.dataPath, "../LogsPasarela/");

    public static void LogToFile(string nombreScript, string mensaje)
    {
        try
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(folderPath, $"{nombreScript}.log");
            string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string lineaLog = $"[{timestamp}] {mensaje}\n";

            File.AppendAllText(filePath, lineaLog, Encoding.UTF8);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error al escribir en el log de {nombreScript}: {e.Message}");
        }
    }
}