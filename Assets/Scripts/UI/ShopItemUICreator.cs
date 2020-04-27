using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A class used to construct a single shop item.
/// </summary>
public class ShopItemUICreator : MonoBehaviour
{
    public GameObject shopItemUIPrefab;

    private static ShopItemUICreator instance;

    public static ShopItemUICreator INSTANCE
    {
        get
        {
            return instance;
        }

        private set
        {
            instance = value;
        }
    }

    void Start()
    {

        INSTANCE = this;

        foreach(ItemUpgradeManager item in ShopSaveSystem.upgradeManagers)
        {
            CreateNewUIForItem(item);
        }

    }
    /// <summary>
    /// Creates a single shop UI item linked to a ItemUpgradeManager.
    /// For more information see ItemUpgradeManager.
    /// </summary>
    /// <param name="item"></param>
    public void CreateNewUIForItem(ItemUpgradeManager item)
    {
        GameObject ShopUIItem = Instantiate(shopItemUIPrefab, gameObject.transform);

        ShopUIItem.transform.SetParent(gameObject.transform, false);
        ShopUIItem.GetComponent<ShopItemUI>().ItemManager = item;
    }

}
