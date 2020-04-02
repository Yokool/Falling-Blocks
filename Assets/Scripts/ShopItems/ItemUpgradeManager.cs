using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class ItemUpgradeManager
{

    public string path;

    public ItemUpgradeManager(string i_name, string description, int cost, Sprite image, float costIncrementor, int maxUpgradeAmount, IShopOnBuy shopOnBuy)
    {
        this.path = Application.persistentDataPath + "/" + i_name + ".itemmanager";

        ItemUpgradeManager loaded = Load();
        if (loaded != null)
        {
            i_name = loaded.i_name;
            description = loaded.description;
            cost = loaded.cost;
            image = loaded.image;
            costMultiplier = loaded.costMultiplier;
            maxUpgradeAmount = loaded.maxUpgradeAmount;
        }

        this.i_name = i_name;
        this.description = description;
        this.cost = cost;
        this.image = image;
        this.costMultiplier = costIncrementor;
        this.maxUpgradeAmount = maxUpgradeAmount;

        this.shopOnBuy = shopOnBuy;

        

    }

    private string i_name;
    private string description;

    private int cost;

    [System.NonSerialized]
    private Sprite image;

    private float costMultiplier;

    private int currentUpgrade = 1;
    private int maxUpgradeAmount;

    [System.NonSerialized]
    private IShopOnBuy shopOnBuy;

    public void Save()
    {

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(path, FileMode.Create);

        binaryFormatter.Serialize(fileStream, this);

        fileStream.Close();

    }

    public ItemUpgradeManager Load()
    {

        if (!File.Exists(path))
        {
            return null;
        }

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(path, FileMode.Open);

        if(fileStream.Length == 0)
        {
            return null;
        }

        ItemUpgradeManager loaded = binaryFormatter.Deserialize(fileStream) as ItemUpgradeManager;

        fileStream.Close();

        return loaded;

    }

    public string I_Name
    {
        get
        {
            return i_name;
        }

        set
        {
            i_name = value;
        }
    }

    public string Description
    {

        get
        {
            return description;
        }

        set
        {
            description = value;
        }

    }

    public Sprite ItemImage
    {
        get
        {
            return image;
        }

        set
        {
            image = value;
        }
    }

    public int Cost
    {
        get
        {
            return cost;
        }

        set
        {
            cost = value;
        }
    }

    public float CostMultiplier
    {
        get
        {
            return costMultiplier;
        }

        set
        {
            costMultiplier = value;
        }
    }

    public int CurrentUpgrade
    {
        get
        {
            return currentUpgrade;
        }

        set
        {
            currentUpgrade = value;
        }
    }

    public int MaxUpgradeAmount
    {
        get
        {
            return maxUpgradeAmount;
        }

        set
        {
            maxUpgradeAmount = value;
            
        }
    }

    public IShopOnBuy ShopOnBuy
    {
        get
        {
            return shopOnBuy;
        }
        set
        {
            shopOnBuy = value;
        }
    }



}
