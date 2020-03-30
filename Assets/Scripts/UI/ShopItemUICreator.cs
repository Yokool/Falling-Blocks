using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemUICreator : MonoBehaviour
{
    public GameObject shopItemUIPrefab;

    void Start()
    {

        foreach (ShopItemValues item in ShopAssetManager.loadedItemValues)
        {

            GameObject ShopUIItem = Instantiate(shopItemUIPrefab, gameObject.transform);

            ShopUIItem.transform.SetParent(gameObject.transform, false);

            ShopUIItem.GetComponent<ShopItemUI>().TiedItem = item;


        }

    }

    void Update()
    {
        
        

    }
}
