using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossBoxScript : MonoBehaviour
{

    public GameObject linkedMap;



    void Start()
    {

        gameObject.transform.position = linkedMap.transform.position + new Vector3(0, -13, 0);
        gameObject.GetComponent<BoxCollider>().size = new Vector3(5000, 3, 5000);

    }

    void Update()
    {

        

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag.Equals("Meteor"))
        {
            Destroy(collision.gameObject);
            return;
        }

        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("--- YOU LOST ---");
            return;
        }

    }
}
