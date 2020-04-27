using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface OnActionClick
{

    void OnPress(BaseEventData data);
    void OnHold(BaseEventData data);
    void OnRelease(BaseEventData data);

}
