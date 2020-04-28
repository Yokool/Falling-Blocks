using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Strength_Buy : IShopOnBuy
{
    public void OnBuy()
    {
        ShopSaveSystem.SerializedJump.jumpHeight += GameConstants.jumpHeight_BUY;
        ShopSaveSystem.SerializedJump.SaveToFile();
    }
}

public class Jump_ReduceCooldown_Buy : IShopOnBuy
{
    public void OnBuy()
    {
        ShopSaveSystem.SerializedJump.jumpCooldown -= GameConstants.jumpCooldown_BUY;
        ShopSaveSystem.SerializedJump.SaveToFile();
    }
}