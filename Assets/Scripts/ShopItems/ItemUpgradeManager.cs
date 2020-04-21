using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using UnityEngine;

[System.Serializable]
public class ItemUpgradeManager
{
    /// <summary>
    /// USED ONLY DURING SERIALIZATION
    /// </summary>
    public ItemUpgradeManager()
    {

    }
    public ItemUpgradeManager(string i_name, string description, int cost, Sprite image, float costIncrementor, int maxUpgradeAmount, IShopOnBuy shopOnBuy)
    {
        this.path = Application.persistentDataPath + "/" + i_name + ".itemmanager";

        int upgradeTracker = 1;

        ItemUpgradeManager loaded = Load(path);
        if (loaded != null)
        {
            this.i_name = loaded.i_name;
            this.description = loaded.description;

            this.cost = loaded.cost;
            this.costMultiplier = loaded.costMultiplier;

            this.currentUpgrade = loaded.currentUpgrade;
            this.maxUpgradeAmount = loaded.maxUpgradeAmount;

            this.image = image;
            this.shopOnBuy = shopOnBuy;
            return;
        }

        this.i_name = i_name;
        this.description = description;

        this.image = image;

        this.cost = cost;
        this.costMultiplier = costIncrementor;

        this.currentUpgrade = upgradeTracker;
        this.maxUpgradeAmount = maxUpgradeAmount;

        this.shopOnBuy = shopOnBuy;

        ItemUpgradeManager.Save(this.path, this);

    }
    [XmlIgnore]
    public string path;

    private string i_name;
    private string description;

    private int cost;

    private Sprite image;

    private float costMultiplier;

    private int currentUpgrade;
    private int maxUpgradeAmount;

    [XmlIgnore]
    private IShopOnBuy shopOnBuy;

    public static void Save(string path, ItemUpgradeManager itemUpgradeManager)
    {

        XmlSerializer binaryFormatter = new XmlSerializer(typeof(ItemUpgradeManager));
        FileStream fileStream = new FileStream(path, FileMode.Create);

        binaryFormatter.Serialize(fileStream, itemUpgradeManager);

        fileStream.Close();
    }

    public bool CanBuy()
    {
        return ((SaveSystem.dataLoaded.TotalScore >= cost) && (currentUpgrade < maxUpgradeAmount));
    }

    public void BuyItem()
    {
        if (!CanBuy())
        {
            return;
        }
        ++CurrentUpgrade;

        SaveSystem.dataLoaded.TotalScore -= Cost;
        Cost = (int)((float)Cost * CostMultiplier);

        ShopOnBuy.OnBuy();

        ItemUpgradeManager.Save(path, this);
    }

    public static ItemUpgradeManager Load(string path)
    {

        if (!File.Exists(path))
        {
            return null;
        }

        XmlSerializer binaryFormatter = new XmlSerializer(typeof(ItemUpgradeManager));
        FileStream fileStream = new FileStream(path, FileMode.Open);

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

    [XmlIgnore]
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

    [XmlIgnore]
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
