using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ShopAssetManager
{

    public static List<ShopItemValues> loadedItemValues = new List<ShopItemValues>();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
    public static void Initialize()
    {
        CreateInitialItems();
    }

    private static void CreateInitialItems()
    {

        ShopItemValues jump = new ShopItemValues("Jetpack", "Ride this for a joyride.", 10, null, 1.25f, 100);

        AddItemToPool(jump, true);

    }

    public static void AddItemToPool(ShopItemValues item, bool createGUI)
    {

        loadedItemValues.Add(item);

        if (createGUI)
        {
            ShopItemUICreator.INSTANCE.CreateNewUIForItem(item);
        }

    }

}
