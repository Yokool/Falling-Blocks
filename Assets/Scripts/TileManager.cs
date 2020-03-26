using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public Transform tile;
    public Vector2 mapSize;

    public Transform wall;

    public float wallHeight;

    public Transform player;


    public void Start()
    {

        GenerateGround();
        GenerateWalls();

        player.transform.position = transform.position;
        player.transform.Translate(new Vector3(0, 1, 0));

    }

    public void GenerateGround()
    {

        for (int x = 0; x < mapSize.x; ++x)
        {
            for(int y = 0; y < mapSize.y; ++y)
            {

                Vector3 tilePosition = new Vector3(-mapSize.x / 2 + x, 0, -mapSize.y / 2 + y);

                tilePosition *= tile.localScale.x;
                tilePosition *= tile.localScale.y;

                GameObject.Instantiate(tile, transform.position + tilePosition, Quaternion.Euler(Vector3.right * 90));

            }
        }

    }

    public void GenerateWalls()
    {
        // The scale of the top and bottom walls
        Vector3 TBParallelScale = new Vector3(tile.localScale.x * mapSize.x, wallHeight, tile.localScale.z);
        // The scale of the left and right walls
        Vector3 LRParallelScale = new Vector3(tile.localScale.x, wallHeight, tile.localScale.z * mapSize.y);

        Vector3 bottomWallPosition = new Vector3(-tile.localScale.x / 2, 0, -mapSize.y / 2 * tile.localScale.y - tile.localScale.y);

        Vector3 topWallPosition = new Vector3(-tile.localScale.x / 2, 0, mapSize.y / 2 * tile.localScale.y);

        Vector3 leftWallPosition = new Vector3(-mapSize.x / 2 * tile.localScale.x - tile.localScale.x, 0, tile.localScale.z / 2 - tile.localScale.z);

        Vector3 rightWallPosition = new Vector3(mapSize.x / 2 * tile.localScale.x, 0, tile.localScale.z / 2 - tile.localScale.z);

        // Instantiate all the objects
        Transform bottomWall = GameObject.Instantiate(wall, transform.position + bottomWallPosition, Quaternion.Euler(Vector3.zero));
        
        Transform topWall = GameObject.Instantiate(wall, transform.position + topWallPosition, Quaternion.Euler(Vector3.zero));
        
        Transform leftWall = GameObject.Instantiate(wall, transform.position + leftWallPosition, Quaternion.Euler(Vector3.zero));

        Transform rightWall = GameObject.Instantiate(wall, transform.position + rightWallPosition, Quaternion.Euler(Vector3.zero));

        // Set the names and scales of the objects
        setScale(bottomWall, TBParallelScale);

        bottomWall.name = "Bottom Wall";

        setScale(topWall, TBParallelScale);

        topWall.name = "Top Wall";

        setScale(leftWall, LRParallelScale);

        leftWall.name = "Left Wall";

        setScale(rightWall, LRParallelScale);

        rightWall.name = "Right Wall";
        
    }

    private static void setScale(Transform transform, Vector3 scale)
    {

        transform.localScale -= transform.localScale;
        transform.localScale = scale;

        BoxCollider coll = transform.GetComponent<BoxCollider>();

        coll.size += new Vector3(0, 50000, 0);

    }

}
