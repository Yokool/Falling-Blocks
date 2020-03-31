using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveFromListOnDeath : MonoBehaviour
{



    private void OnDestroy()
    {

        
        GameObject tileMap = GameObject.FindGameObjectWithTag("Tilemap");

        if (!tileMap)
        {
            return; // If we are closing from the editor. Avoid null references.
        }


        tileMap.GetComponent<TileManager>().tiles.Remove(tileMap);

    }
}
