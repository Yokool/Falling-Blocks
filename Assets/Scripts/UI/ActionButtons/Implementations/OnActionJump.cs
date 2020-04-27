using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnActionJump : MonoBehaviour, OnActionClick
{
    public void OnHold(BaseEventData data)
    {
        // No implementation
    }

    public void OnPress(BaseEventData data)
    {
        LocalPlayer.INSTANCE.Player.GetComponent<Jump>().PerformJump();
    }

    public void OnRelease(BaseEventData data)
    {
        // No implementation
    }

}
