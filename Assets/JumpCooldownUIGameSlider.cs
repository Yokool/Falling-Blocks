using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCooldownUIGameSlider : UIGameSlider
{

    public CooldownFromSerializedJump cooldown;

    public override float GetCurrentValue()
    {
        if (cooldown.IsActionPossible()) return GetMaxValue(); // This deals with the cooldown being set to 0 when the action is possible
        return cooldown.CurrentTime;
    }

    public override float GetMaxValue()
    {
        Debug.Log(cooldown.GetExternalTimeToHit());
        return cooldown.GetExternalTimeToHit();
    }
}
