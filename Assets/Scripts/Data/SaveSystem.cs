using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{

    static SaveSystem()
    {
        LoadFirstTime();
    }

    /// <summary>
    /// Data loaded from the file. Used universaly throughout the game.
    /// </summary>
    [SerializeField]
    public static PersistentSavedData dataLoaded;

    public const string PERSISTENT_DATA_PATH = "/PERSISTENT_DATA.goodies";

    public static void SavePersistentData()
    {

        
        string path = Application.persistentDataPath + PERSISTENT_DATA_PATH;

        FileStream persistentFile = new FileStream(path, FileMode.Create);
        persistentFile.Position = 0;

        BinaryFormatter formatter = new BinaryFormatter();

        formatter.Serialize(persistentFile, dataLoaded);
        
        persistentFile.Close();

    }

    public static void LoadPersistentData()
    {

        string path = Application.persistentDataPath + PERSISTENT_DATA_PATH;

        FileStream persistentFile = new FileStream(path, FileMode.Open);
        persistentFile.Position = 0;

        BinaryFormatter formatter = new BinaryFormatter();

        PersistentSavedData data = formatter.Deserialize(persistentFile) as PersistentSavedData;


        dataLoaded = data;


        persistentFile.Close();

    }

    public static void LoadFirstTime()
    {
        if (!File.Exists(Application.persistentDataPath + PERSISTENT_DATA_PATH))
        {

            dataLoaded = new PersistentSavedData();
            SavePersistentData();


        }
        else
        {

            LoadPersistentData();

        }

    }
}
