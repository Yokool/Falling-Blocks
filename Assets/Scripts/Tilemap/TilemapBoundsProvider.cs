using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapBoundsProvider : MonoBehaviour, IBoundsProvider
{

    public TileManager tileManager;


    public void Start()
    {
        tileManager = gameObject.GetComponent<TileManager>();

        if (!tileManager)
        {
            Debug.LogError("TilemapBoundsProvider assigned to an object without a TileManager component.");
        }

    }

    public Vector2 GetBounds()
    {
        return new Vector2(tileManager.mapSize.x * tileManager.tile.localScale.x, tileManager.mapSize.y * tileManager.tile.localScale.y) / 2;
    }

}