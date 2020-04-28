using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using UnityEngine;

/// <summary>
/// A serialized class that manages the data of a single shop item.
/// This class contains the functionality for upgrading items through the shop, the image, name etc of the item.
/// 
/// What this class does not contain is the actual data that gets upgraded. That is contained in a SaveableShopItem subclass.
/// </summary>
[System.Serializable]
public class ItemUpgradeManager
{
    /// <summary>
    /// USED ONLY DURING SERIALIZATION
    /// </summary>
    public ItemUpgradeManager()
    {

    }
    /// <summary>
    /// Constructs a new shop item that can be upgraded.
    /// The construction takes place in the ShopSaveSystem. Since the class is serialized. The constructor is used as the data initializer
    /// if the file does not exist.
    /// 
    /// If the file does exist, the constructor takes its data from there.
    /// </summary>
    /// <param name="i_name"></param>
    /// <param name="description"></param>
    /// <param name="cost"></param>
    /// <param name="image"></param>
    /// <param name="costMultiplier"></param>
    /// <param name="maxUpgradeAmount"></param>
    /// <param name="shopOnBuy"></param>
    public ItemUpgradeManager(string i_name, string description, int cost, Sprite image, float costMultiplier, int maxUpgradeAmount, IShopOnBuy shopOnBuy)
    {
        this.path = Application.persistentDataPath + "/" + i_name + ".itemmanager";

        this.i_name = i_name;
        this.description = description;
        this.image = image;
        this.maxUpgradeAmount = maxUpgradeAmount;
        this.shopOnBuy = shopOnBuy;
        this.cost = cost;
        this.currentUpgrade = 1;
        this.costMultiplier = costMultiplier;

        ItemUpgradeManager loaded = Load(path);
        if (loaded != null) // We found the data, get the data from the file.
        {
            this.currentUpgrade = loaded.currentUpgrade;
        }

        ItemUpgradeManager.Save(this.path, this);

    }
    [XmlIgnore]
    public string path;
    /// <summary>
    /// The name of the item that is shown in the ui shop.
    /// </summary>
    [XmlIgnore]
    private string i_name;
    /// <summary>
    /// The description of the item shown in the UI shop.
    /// </summary>
    [XmlIgnore]
    private string description;
    /// <summary>
    /// The cost of the item that is shown in the UI shop.
    /// This variable is influenced by the costMultpilier by being multiplied by it, when the user buys the item.
    /// </summary>
    private int cost;
    /// <summary>
    /// The sprite of the item shown in the UI shop. The Sprite is always taken runtime. It is not serialized.
    /// </summary>
    [XmlIgnore]
    private Sprite image;

    /// <summary>
    /// A float that is usually between 1.0f and more. The costMultiplier influences the cost of the item by multiplying the cost
    /// of the item by this variable.
    /// </summary>
    [XmlIgnore]
    private float costMultiplier;

    /// <summary>
    /// The current upgrade tracker. The user can't buy more items than in maxUpgradeAmount.
    /// </summary>
    [XmlIgnore]
    private int currentUpgrade;

    /// <summary>
    /// How many times we can upgrade the item.
    /// </summary>
    [XmlIgnore]
    private int maxUpgradeAmount;

    /// <summary>
    /// The method of this class gets called when the user clicks the shop buy button when he CAN buy the item. (Having enough money.)
    /// 
    /// See IShopOnBuy for more information.
    /// </summary>
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
        return ((PersistentDataSaveSystem.dataLoaded.TotalScore >= Cost) && (currentUpgrade < maxUpgradeAmount));
    }

    public void BuyItem()
    {
        if (!CanBuy())
        {
            return;
        }
        
        PersistentDataSaveSystem.dataLoaded.TotalScore -= Cost;

        ++CurrentUpgrade;

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
    [XmlIgnore]
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
    [XmlIgnore]
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
    [XmlIgnore]
    public int Cost
    {
        get
        {
            int _cost = cost;
            for(int i = 2; i <= CurrentUpgrade; ++i)
            {
                _cost += (int)((cost * (costMultiplier)) * CurrentUpgrade);
            }
            return _cost;
        }

        set
        {
            cost = value;
        }
    }
    [XmlIgnore]
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
    [XmlIgnore]
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
