using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownFromSerializedJump : ExternalValueCooldownDeterminator
{
    public override float GetExternalTimeToHit()
    {
        return ShopSaveSystem.SerializedJump.jumpCooldown;
    }

}
