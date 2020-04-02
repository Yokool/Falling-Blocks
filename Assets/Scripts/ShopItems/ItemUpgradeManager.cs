using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemUpgradeManager
{
    
    public ItemUpgradeManager(string i_name, string description, int cost, Sprite image, float costIncrementor, int maxUpgradeAmount, IShopOnBuy shopOnBuy)
    {

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

    private Sprite image;

    private float costMultiplier;

    private int currentUpgrade = 1;
    private int maxUpgradeAmount;

    [System.NonSerialized]
    private IShopOnBuy shopOnBuy;

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
