using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpriteDatabase
{

    public static Sprite RefuelPipes;
    public static Sprite Canister;
    public static Sprite JetEngine;
    public static Sprite GoldenMask;
    public static Sprite MechanicalLeg;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
    public static void LoadSprites()
    {
        RefuelPipes = Resources.Load<Sprite>("ShopIcons/FuelPipe");
        Canister = Resources.Load<Sprite>("ShopIcons/Canister");
        JetEngine = Resources.Load<Sprite>("ShopIcons/JetEngine");
        GoldenMask = Resources.Load<Sprite>("ShopIcons/GoldenMask");
        MechanicalLeg = Resources.Load<Sprite>("ShopIcons/MechanicalLeg");
    }

}
