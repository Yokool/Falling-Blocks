using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAbove : MonoBehaviour
{

    public Transform spawnedThing;

    public float height;

    public float time;

    private float savedTime;

    public TilemapBoundsProvider boundsProvider;



    void Start()
    {
        boundsProvider = gameObject.GetComponent<TilemapBoundsProvider>();
        savedTime = time;
        time = 0;
    }

    void Update()
    {

        time += Time.deltaTime;

        if(time >= savedTime)
        {
            time = 0;
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
