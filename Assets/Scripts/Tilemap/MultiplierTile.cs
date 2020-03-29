using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierTile : MonoBehaviour
{

    private void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0);

    }

    private void OnDestroy()
    {



        GameObject tilemap = GameObject.FindGameObjectWithTag("Tilemap");

        if (!tilemap)
        {
            return; // So we don't get editor nulls.
        }

        tilemap.GetComponent<TileManager>().SpawnMultiplierTile();
    }

    private void OnCollisionEnter(Collision collision)
    {

        GameObject.FindGameObjectWithTag("Player").GetComponent<Score>().scoreMultiplier += 0.1f;
        Destroy(gameObject.GetComponent<MultiplierTile>());

    }
}
