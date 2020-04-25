using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDeath : MonoBehaviour, IOnDeath
{
    private Material objMat;
    private int colorTracker = 1;

    public void OnDeath()
    {
        objMat = GetComponent<Renderer>().material;
        StartCoroutine(DestroyWithDelay());
        
    }

    public IEnumerator DestroyWithDelay()
    {

        
        for(int i = 0; i < GameCodeConstants.TransitionFraction; ++i)
        {
            ChangeCol();
            yield return new WaitForSeconds(GameCodeConstants.TransitionTime / GameCodeConstants.TransitionFraction);
        }
        
        
        
        GameObject.Destroy(gameObject);
    }

    private void ChangeCol()
    {
        Color objCol = objMat.color;
        float rgb = Mathf.Lerp(1f, 0f, colorTracker / (float)GameCodeConstants.TransitionFraction);
        objCol.r = rgb;
        objCol.g = rgb;
        objCol.b = rgb;
        objMat.color = objCol;
        ++colorTracker;
    }
}
