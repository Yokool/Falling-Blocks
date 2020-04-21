using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{

    public Transform objectToDestroy;

    public virtual void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag.Equals(objectToDestroy.tag))
        {
            GameObject.Destroy(collision.gameObject);
        }

    }

}
