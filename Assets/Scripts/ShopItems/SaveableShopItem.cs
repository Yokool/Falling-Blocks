using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using UnityEngine;
/// <summary>
/// 
/// This class provides general functionality for saving the item shop data.
/// 
/// If you want a script to have data that can be serialized and altered with the shop, use extend this class.
/// 
/// This class manages a few things and makes a few contracts. It is aware of its own path where it's stored.
/// It also knows how to save itself and load itself.
/// 
/// The user should worry only about the abstract methods and the generic.
/// 
/// The generic defines the script that can have its data serialized.
/// 
/// This class is mainly used to hold data of the script we want to serialize.
/// 
/// It has methods to construct and deconstruct the data from this class.
/// 
/// The correct instantiation of this class must be done inside ShopSaveSystem initialization method.
/// 
/// </summary>
/// <typeparam name="T">The script to serialize.</typeparam>
[System.Serializable]
public abstract class SaveableShopItem<T> where T : MonoBehaviour
{

    [XmlIgnore]
    protected string filePath;

    /// <summary>
    /// USED ONLY DURING DESERIALIZATION
    /// </summary>
    public SaveableShopItem()
    {

    }

    public SaveableShopItem(string filePath)
    {
        this.filePath = filePath;

        if(File.Exists(Application.persistentDataPath + filePath))
        {
            LoadValuesFromFile();
        }
        else
        {
            LoadDefaultValues();
            SaveToFile();
        }

    }
    /// <summary>
    /// Serializes the object into a file.
    /// DO NOT CALL THIS ON YOUR OWN
    /// </summary>
    public abstract void SaveToFile();

    /// <summary>
    /// Deserializes the class. Should be used by LoadValuesFromFile for easy access to stored data.
    /// Should not be used anywhere else in the code.
    /// </summary>
    /// <returns></returns>
    protected FileStream LoadAssociatedFile()
    {
        FileStream fileStream = new FileStream(Application.persistentDataPath + filePath, FileMode.OpenOrCreate);
        return fileStream;

    }
    /// <summary>
    /// Initialization script for this class. Must be implemented. Should call the LoadAssociatedFile method
    /// in order for this method to be implemented correctly.
    /// </summary>
    public abstract void LoadValuesFromFile();
    /// <summary>
    /// Sets the values of this object from a compatible script. Think of it as a second constructor that sets all the
    /// valus.
    /// </summary>
    /// <param name="script"></param>
    public abstract void SetValues(T script);
    /// <summary>
    /// Sets the values of the compatible script with the values currently stored inside the object.
    /// </summary>
    /// <param name="script"></param>
    public abstract void PopulateScript(T script);
    /// <summary>
    /// Loads the default values for a script, when the serialized file can't be found.
    /// </summary>
    public abstract void LoadDefaultValues();

}
