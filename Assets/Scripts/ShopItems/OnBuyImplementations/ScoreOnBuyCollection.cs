using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnBuyMultiplier : IShopOnBuy
{
    public void OnBuy()
    {
        ShopSaveSystem.SerializedScore.scoreMultiplier += GameConstants.scoreMultiplier_BUY;
    }

}
