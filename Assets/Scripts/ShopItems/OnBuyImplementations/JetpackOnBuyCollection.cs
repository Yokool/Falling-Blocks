using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack_Refuel_Buy : IShopOnBuy
{
    public void OnBuy()
    {

        ShopSaveSystem.SerializedJetpack.jetpackRefuelIncrement += 0.0025f;
        ShopSaveSystem.SerializedJetpack.SaveToFile();

    }
}

public class Jetpack_SpendfuelDecrement_Buy : IShopOnBuy
{
    public void OnBuy()
    {
        ShopSaveSystem.SerializedJetpack.jetpackSpendFuelDecrement -= 0.005f;
        ShopSaveSystem.SerializedJetpack.SaveToFile();
    }
}

public class Jetpack_Maxfuel_Buy : IShopOnBuy
{
    public void OnBuy()
    {
        ShopSaveSystem.SerializedJetpack.maxFuel += 1f;
    }
}

public class Jetpack_Strength_Buy : IShopOnBuy
{
    public void OnBuy()
    {
        ShopSaveSystem.SerializedJetpack.jetpackStrength += 0.1f;
    }
}