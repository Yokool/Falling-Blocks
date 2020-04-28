using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpriteDatabase
{

    public static Sprite RefuelPipes;
    public static Sprite FuelCanister;
    public static Sprite JetEngine;
    public static Sprite GoldenMask;
    public static Sprite MechanicalLeg;
    public static Sprite DeedRed;
    public static Sprite DeedBlue;
    public static Sprite FuelTank;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
    public static void LoadSprites()
    {
        RefuelPipes = Resources.Load<Sprite>("ShopIcons/FuelPipe");
        FuelCanister = Resources.Load<Sprite>("ShopIcons/Canister");
        JetEngine = Resources.Load<Sprite>("ShopIcons/JetEngine");
        GoldenMask = Resources.Load<Sprite>("ShopIcons/GoldenMask");
        MechanicalLeg = Resources.Load<Sprite>("ShopIcons/MechanicalLeg");
        DeedRed = Resources.Load<Sprite>("ShopIcons/DeedRed");
        DeedBlue = Resources.Load<Sprite>("ShopIcons/DeedBlue");
        FuelTank = Resources.Load<Sprite>("ShopIcons/FuelTank");
    }

}
