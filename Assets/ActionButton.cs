using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(OnActionClick))]
[RequireComponent(typeof(EventTrigger))]
[RequireComponent(typeof(ActionDeterminator))]
public class ActionButton : MonoBehaviour, OnActionClick
{

    private OnActionClick actionHandler;

    private EventTrigger eventTrigger;

    private ActionDeterminator actionDeterminator;

    private bool holding = false;

    private void Start()
    {
        OnActionClick[] componentList = GetComponents<OnActionClick>();
        
        foreach(OnActionClick onAction in componentList)
        {
            if (!onAction.Equals(this))
            {
                actionHandler = onAction;
            }
        }

        eventTrigger = GetComponent<EventTrigger>();
        actionDeterminator = GetComponent<ActionDeterminator>();

        SetTriggers(this);
    }

    private void SetTriggers(OnActionClick onAction)
    {
        EventTrigger.Entry onPress = new EventTrigger.Entry();
        EventTrigger.Entry onHold = new EventTrigger.Entry();
        EventTrigger.Entry onRelease = new EventTrigger.Entry();

        onPress.eventID = EventTriggerType.PointerClick;
        onHold.eventID = EventTriggerType.PointerDown;
        onRelease.eventID = EventTriggerType.PointerUp;

        onPress.callback.AddListener(onAction.OnPress);
        onHold.callback.AddListener(onAction.OnHold);
        onRelease.callback.AddListener(onAction.OnRelease);

        
        eventTrigger.triggers.Add(onHold);
        eventTrigger.triggers.Add(onPress);
        eventTrigger.triggers.Add(onRelease);
        
    }

    public void OnPress(BaseEventData data)
    {
        if (!actionDeterminator.IsActionPossible())
        {
            return;
        }
        actionHandler.OnPress(data);
        actionDeterminator.SetActionPossible(false); // <- On press gets called last
    }

    public void OnHold(BaseEventData data)
    {
        if (!actionDeterminator.IsActionPossible())
        {
            return;
        }
        holding = true;
        actionHandler.OnHold(data);
    }

    public void OnRelease(BaseEventData data)
    {
        if (!holding || !actionDeterminator.IsActionPossible())
        {
            return;
        }
        holding = false;
        actionHandler.OnRelease(data);
        
    }
}
