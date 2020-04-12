using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnBuyMultiplier : IShopOnBuy
{
    public void OnBuy()
    {
        ShopSaveSystem.SerializedScore.scoreMultiplier += 0.1f;
    }

}
