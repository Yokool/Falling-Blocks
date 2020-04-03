using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void CreateNewUIForItem(ItemUpgradeManager item)
    {
        GameObject ShopUIItem = Instantiate(shopItemUIPrefab, gameObject.transform);

        ShopUIItem.transform.SetParent(gameObject.transform, false);

        ShopUIItem.GetComponent<ShopItemUI>().ItemManager = item;
    }

}
