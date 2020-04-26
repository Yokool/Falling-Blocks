using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownDeterminator : MonoBehaviour, ActionDeterminator
{
    [SerializeField]
    private float timeToHit;

    [SerializeField] // <-- serialized for testing for the inspector
    private float currentTime = 0;

    private bool actionPossible = false;

    public bool IsActionPossible()
    {
        return actionPossible;
    }

    public void SetActionPossible(bool action)
    {
        actionPossible = action;
    }

    void Update()
    {
        if (IsActionPossible()) // There is no cooldown, action is possible but the user did not yet perform it
        {
            // so wait until the user does the action
            return;
        }

        
        if(currentTime <= timeToHit) // Waiting for the cooldown
        {
            currentTime += Time.deltaTime;
        }
        else // Cooldown hit
        {
            currentTime = 0f;
            SetActionPossible(true);
        }

    }
}
