using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{

    public GameObject objectToFollow;

    public Vector3 offsets;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = objectToFollow.transform.position;

        pos.x += offsets.x;
        pos.y += offsets.y;
        pos.z += offsets.z;

        gameObject.transform.position = pos;


    }

    
}
