using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
/// <summary>
/// Static class for saving and loading persistent data.
/// 
/// Contains a field for the persistent data.
/// 
/// SHOP SYSTEM USES A DIFFERENT SYSTEM.
/// </summary>
public static class PersistentDataSaveSystem
{
    /// <summary>
    /// 
    /// </summary>
    static PersistentDataSaveSystem()
    {
        LoadFirstTime();
    }

    /// <summary>
    /// Persistent data of the game.
    /// </summary>
    [SerializeField]
    public static PersistentSavedData dataLoaded;
    /// <summary>
    /// A path to the persistent data.
    /// </summary>
    public const string PERSISTENT_DATA_PATH = "/PERSISTENT_DATA.goodies";
    /// <summary>
    /// Saves the persistent data field to its file. The user can use this method although 
    /// the field is also saved when the user exits the application.
    /// 
    /// If you want to be sure your data gets saved if the application would be to crash. Serialize it using this method.
    /// </summary>
    public static void SavePersistentData()
    {

        
        string path = Application.persistentDataPath + PERSISTENT_DATA_PATH;

        FileStream persistentFile = new FileStream(path, FileMode.Create);
        persistentFile.Position = 0;

        BinaryFormatter formatter = new BinaryFormatter();

        formatter.Serialize(persistentFile, dataLoaded);
        
        persistentFile.Close();

    }
    /// <summary>
    /// Loads persistent data from the file. The user should should not use this class as the data needs to be loaded only
    /// once, that is during the start of the application.
    /// </summary>
    public static void LoadPersistentData()
    {

        string path = Application.persistentDataPath + PERSISTENT_DATA_PATH;

        FileStream persistentFile = new FileStream(path, FileMode.Open);
        persistentFile.Position = 0;

        BinaryFormatter formatter = new BinaryFormatter();

        PersistentSavedData data = formatter.Deserialize(persistentFile) as PersistentSavedData;


        dataLoaded = data;


        dataLoaded.TotalScore = 9999e28f; // REMOVE!!!!

        persistentFile.Close();

    }
    /// <summary>
    /// Used to load the persistent data for the first time. If the file does not exist a new one is created and
    /// initialized through the default constructor of the persistent saved data.
    /// </summary>
    private static void LoadFirstTime()
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
