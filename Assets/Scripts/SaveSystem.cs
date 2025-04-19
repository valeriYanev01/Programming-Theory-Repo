using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private readonly static string savePath = Application.persistentDataPath + "/playerData.json";

    public static void SavePlayer(PlayerData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Saved to: " + savePath);
    }

    public static PlayerData LoadPlayer()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            return JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            Debug.Log("No save file found at: " + savePath);
            return null;
        }
    }
}
