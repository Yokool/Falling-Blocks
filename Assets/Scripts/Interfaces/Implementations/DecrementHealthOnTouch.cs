using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecrementHealthOnTouch : MonoBehaviour, IOnTouch
{
    public void OnTouch(GameObject collidingObject)
    {

        HealthTracker collidingObjectHealth = collidingObject.GetComponent<HealthTracker>();

        if (collidingObjectHealth)
        {
            
            collidingObjectHealth.TakeDamage(1);
        }

    }
}