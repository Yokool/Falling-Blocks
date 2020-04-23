using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpriteDatabase
{

    public static Sprite RefuelPipes;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
    public static void LoadSprites()
    {
        RefuelPipes = Resources.Load<Sprite>("ShopIcons/S_FuelPipe");
        Debug.Log(RefuelPipes);
    }

}
