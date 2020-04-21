using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollisionWParticles : DestroyOnCollision
{
    public GameObject explosionParticle;
    private void Start()
    {
        
    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        Instantiate(explosionParticle, gameObject.transform.position, Quaternion.Euler(Vector3.zero));
    }
}
