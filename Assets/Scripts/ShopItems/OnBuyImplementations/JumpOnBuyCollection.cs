using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Strength_Buy : IShopOnBuy
{
    public void OnBuy()
    {
        ShopSaveSystem.SerializedJump.jumpHeight += 25;
    }
}