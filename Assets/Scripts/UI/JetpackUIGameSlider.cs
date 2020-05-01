using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackUIGameSlider : UIGameSlider
{
    [SerializeField]
    private Jetpack jetpackScript;

    public override float GetCurrentValue()
    {
        return jetpackScript.jetpackFuel;
    }

    public override float GetMaxValue()
    {
        return jetpackScript.maxFuel;
    }

}