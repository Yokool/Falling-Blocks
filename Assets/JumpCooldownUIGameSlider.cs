using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCooldownUIGameSlider : UIGameSlider
{

    public CooldownFromSerializedJump cooldown;

    public override float GetCurrentValue()
    {
        return cooldown.CurrentTime;
    }

    public override float GetMaxValue()
    {
        Debug.Log(cooldown.GetExternalTimeToHit());
        return cooldown.GetExternalTimeToHit();
    }
}
