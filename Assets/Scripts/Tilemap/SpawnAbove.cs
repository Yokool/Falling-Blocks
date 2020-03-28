using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAbove : MonoBehaviour
{
    /// <summary>
    /// The thing to spawn.
    /// </summary>
    public Transform spawnedThing;
    /// <summary>
    /// The height to spawn the spawnedThing above the playing field.
    /// </summary>
    public float height;

    /// <summary>
    /// Set by the editor, the actual variable tracking the time. Compared to savedTime.
    /// </summary>
    public float time;

    /// <summary>
    /// 
    /// To understand this variable, we have to think about how the savedTime var works.
    /// Upon each spawn of the meteorite, the savedTime gets decremented.
    /// If the decrementation would reach under the bottom bounds, the decrementing stops, and the savedTime
    /// gets set to the bottom bounds.
    /// 
    /// It is important to note that the bottom bound gets also multiplied in this script.
    /// The bottomBound is directly tied to the size of the playing field.
    /// 
    /// The standart for the playing field is 10 x 10 - resulting in the bottom bound variabl getting multiplied by 1.
    /// 
    /// If the playing field is for example 100 x 100, the variable would be multiplied by 0.1. Resulting in bigger playing fields
    /// having a smaller bottom bound. Meaning more meteorites can spawn on bigger maps.
    /// 
    /// </summary>
    public float bottomBound;

    /// <summary>
    /// Time to reach when spawning the object. time variable is checked against this one.
    /// savedTime is equal to the time variable at the start of this script.
    /// </summary>
    public float savedTime;

    private bool stopDecrementing = false;

    public TilemapBoundsProvider boundsProvider;

    private float totalTimePassed;

    void Start()
    {
        boundsProvider = gameObject.GetComponent<TilemapBoundsProvider>();
        savedTime = time;
        time = 0;

        bottomBound /= boundsProvider.GetBounds().magnitude / new Vector2(5, 5).magnitude;
    }

    void Update()
    {

        time += Time.deltaTime;
        totalTimePassed += Time.deltaTime;

        if (time >= savedTime) // We reached the time to reach
        {
            time = 0; // Reset the time
            
            if (!stopDecrementing) // If we shouldn't stop decrementing our time to reach
            {
                savedTime -= (1/totalTimePassed) * 0.5f; // Decrement the time to reach
            }
            
            if(savedTime <= bottomBound) // If we went under the bottom bounds of the time to reach
            {
                stopDecrementing = true; // Stop decrementing our number
                savedTime = bottomBound; // And set the time to reach to its bottom bounds.
            }

            SpawnThing();
        }

    }

    public Transform SpawnThing()
    {

        Vector2 bounds = boundsProvider.GetBounds();
        Vector3 loc = new Vector3(Random.Range(-bounds.x, bounds.x), height, Random.Range(-bounds.y, bounds.y));

        return Transform.Instantiate(spawnedThing, gameObject.transform.position + loc, Quaternion.Euler(Vector2.zero));

    }
    
}
