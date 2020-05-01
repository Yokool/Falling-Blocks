using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDatabase
{
    public static SoundDatabase INSTANCE;

    public static AudioClip DestroyTileSFX;
    public static AudioClip JumpSFX;
    public static AudioClip OnDeathSFX;
    public static AudioClip PickupMultiplierSFX;

    // Music
    public static AudioClip Game_Theme;
    public static AudioClip GameOver_Tune;
    public static AudioClip ShopTheme;


    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
    public static void Initialize()
    {
        DestroyTileSFX = Resources.Load<AudioClip>("SoundFX/DestroyTileSFX");
        JumpSFX = Resources.Load<AudioClip>("SoundFX/JumpSFX");
        OnDeathSFX = Resources.Load<AudioClip>("SoundFX/OnDeathSFX");
        PickupMultiplierSFX = Resources.Load<AudioClip>("SoundFX/PickupMultiplierSFX");

        Game_Theme = Resources.Load<AudioClip>("SoundFX/Game_Theme");
        GameOver_Tune = Resources.Load<AudioClip>("SoundFX/GameOver_Tune");
        ShopTheme = Resources.Load<AudioClip>("SoundFX/ShopTheme");
    }

}
