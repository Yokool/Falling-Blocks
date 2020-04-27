using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierTile : MonoBehaviour
{

    private void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = GameCodeConstants.DarkRedColor; // Dark Red
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
        // Meteorites also trigger the multiplier: INTENDED!
        GameObject.FindGameObjectWithTag("Player").GetComponent<Score>().scoreMultiplier += 0.1f;
        Destroy(gameObject.GetComponent<MultiplierTile>());
        GetComponent<HealthTracker>().TakeDamage(10000f);
        AudioManager.INSTANCE.PlaySound(SoundDatabase.PickupMultiplierSFX);

    }
}
