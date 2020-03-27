using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDeath : MonoBehaviour, IOnDeath
{
    public void OnDeath()
    {

        StartCoroutine(DestroyWithDelay());
        
    }

    public IEnumerator DestroyWithDelay()
    {
        yield return new WaitForSeconds(1);
        GameObject.Destroy(gameObject);
    }
}
