using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnActionJetpack : MonoBehaviour, OnActionClick
{
    private Jetpack cachedJetpack;

    void Start()
    {
        
    }

    public void OnHold(BaseEventData data)
    {
        if (cachedJetpack == null)
        {
            cachedJetpack = LocalPlayer.INSTANCE.Player.GetComponent<Jetpack>();
        }

        if (cachedJetpack.jetpackFuel > 0)
        {
            cachedJetpack.flying = true;
        }

    }

    public void OnPress(BaseEventData data)
    {
        // No implementation
    }

    public void OnRelease(BaseEventData data)
    {
        cachedJetpack.flying = false;
    }
}
