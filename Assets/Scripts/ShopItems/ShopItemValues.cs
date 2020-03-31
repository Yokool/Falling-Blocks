using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemValues
{
    
    public ShopItemValues(string i_name, string description, int cost, Sprite itemImage, float costIncrementor, int maxUpgradeAmount)
    {

        this.i_name = i_name;
        this.description = description;
        this.cost = cost;
        this.itemImage = itemImage;
        this.costMultiplier = costIncrementor;
        this.maxUpgradeAmount = maxUpgradeAmount;

    }


    private string i_name;
    private string description;

    private int cost;

    private Sprite itemImage;

    private float costMultiplier;

    private int currentUpgrade = 1;
    private int maxUpgradeAmount;

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
            return itemImage;
        }

        set
        {
            itemImage = value;
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


}
