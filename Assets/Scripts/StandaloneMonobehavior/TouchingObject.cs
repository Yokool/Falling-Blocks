using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingObject : MonoBehaviour
{

    public GameObject gameObjectToCheck;

    public IOnTouch onTouch;

    void Start()
    {
        onTouch = gameObject.GetComponent<IOnTouch>();
    }

    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag.Equals(gameObjectToCheck.tag))
        {
            onTouch.OnTouch(collision.gameObject);
        }

    }
}



