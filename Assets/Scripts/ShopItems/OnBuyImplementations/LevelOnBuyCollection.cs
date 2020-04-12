using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOnBuyWidth : IShopOnBuy
{
    public void OnBuy()
    {
        ShopSaveSystem.SerializedLevel.levelWidth += 1;
        ShopSaveSystem.SerializedLevel.SaveToFile();
    }
}

public class LevelOnBuyHeight : IShopOnBuy
{
    public void OnBuy()
    {
        ShopSaveSystem.SerializedLevel.levelHeight += 1;
        ShopSaveSystem.SerializedLevel.SaveToFile();
    }
}
