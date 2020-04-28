using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ExternalValueCooldownDeterminator : CooldownDeterminator
{
    public abstract float GetExternalTimeToHit();

    private void Start()
    {
        timeToHit = GetExternalTimeToHit();
    }
}
