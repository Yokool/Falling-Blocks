using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SHOP_ITEM_SO", menuName = "Create new shop item")]
public class ShopItemValues : ScriptableObject
{

    public string i_name;
    public string description;

    public Sprite itemImage;

    public int cost;

    public int costIncrementor;

    public int currentUpgrade = 1;
    public int maxUpgradeAmount;

}
