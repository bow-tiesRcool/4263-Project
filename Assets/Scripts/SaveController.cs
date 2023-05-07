using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveController
{
    public static void SavePlayer(PlayerController player)
    {
        BinaryFormatter formatter= new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.idk";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.idk";
        if (File.Exists(path))
        {
            BinaryFormatter formatter= new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file is not found in " + path);
            return null;
        }
    }
}
