using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnJetpackShopBuy : IShopOnBuy
{
    public void OnBuy()
    {

        ShopSaveSystem.SerializedJetpack.jetpackRefuelIncrement = 4500f;

    }
}
