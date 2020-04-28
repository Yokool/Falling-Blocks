using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOnBuyWidth : IShopOnBuy
{
    public void OnBuy()
    {
        ShopSaveSystem.SerializedLevel.levelWidth += GameConstants.levelWidth_BUY;
        ShopSaveSystem.SerializedLevel.SaveToFile();
    }
}

public class LevelOnBuyHeight : IShopOnBuy
{
    public void OnBuy()
    {
        ShopSaveSystem.SerializedLevel.levelHeight += GameConstants.levelHeight_BUY;
        ShopSaveSystem.SerializedLevel.SaveToFile();
    }
}
