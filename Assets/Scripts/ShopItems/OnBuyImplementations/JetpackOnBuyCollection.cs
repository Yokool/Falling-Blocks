using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack_Refuel_Buy : IShopOnBuy
{
    public void OnBuy()
    {

        ShopSaveSystem.SerializedJetpack.jetpackRefuelIncrement += GameConstants.jetpackRefuelIncrement_BUY;
        ShopSaveSystem.SerializedJetpack.SaveToFile();

    }
}

public class Jetpack_SpendfuelDecrement_Buy : IShopOnBuy
{
    public void OnBuy()
    {
        ShopSaveSystem.SerializedJetpack.jetpackSpendFuelDecrement -= GameConstants.jetpackSpendFuelDecrement_BUY;
        ShopSaveSystem.SerializedJetpack.SaveToFile();
    }
}

public class Jetpack_Maxfuel_Buy : IShopOnBuy
{
    public void OnBuy()
    {
        ShopSaveSystem.SerializedJetpack.maxFuel += GameConstants.maxFuel_BUY;
        ShopSaveSystem.SerializedJetpack.SaveToFile();
    }
}

public class Jetpack_Strength_Buy : IShopOnBuy
{
    public void OnBuy()
    {
        ShopSaveSystem.SerializedJetpack.jetpackStrength += GameConstants.jetpackStrength_BUY;
        ShopSaveSystem.SerializedJetpack.SaveToFile();
    }
}