using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollisionWParticles : DestroyOnCollision
{
    public GameObject explosionParticle;
    
    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        Instantiate(explosionParticle, gameObject.transform.position, Quaternion.Euler(Vector3.zero));
        AudioSource.PlayClipAtPoint(SoundDatabase.DestroyTileSFX, gameObject.transform.position);
        Destroy(gameObject); // Destroy The Meteorite
    }
}
