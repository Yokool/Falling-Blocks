using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ShopAssetManager
{

    public static string scriptableObjectPath = "\\Shop\\ItemValueScriptableObjects\\";

    public static List<ShopItemValues> loadedItemValues = new List<ShopItemValues>();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
    public static void Initialize()
    {

        string[] files = Directory.GetFiles(Application.dataPath + scriptableObjectPath);


        foreach(string file in files)
        {
            string[] split = file.Split(new string[] { "Assets" }, StringSplitOptions.None);

            string actualFile = "Assets" + split[1];
            

            ShopItemValues scriptableObject = AssetDatabase.LoadAssetAtPath<ShopItemValues>(actualFile);

            Debug.Log(scriptableObject);

            if (!scriptableObject) // Ignore misc files and .meta files.
            {
                continue;
            }
            
            loadedItemValues.Add(scriptableObject);

        }

        foreach(ShopItemValues item in loadedItemValues)
        {
            Debug.Log(item);
        }

        if (loadedItemValues == null)
        {

            Debug.LogWarning("No item value scriptable objects found at path " + scriptableObjectPath);
            
        }

    }

}
