using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed;

    public Rigidbody rigidBody;

    void Start()
    {

        rigidBody = GetComponent<Rigidbody>();

    }

    
    void Update()
    {


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector2 movementVector = new Vector2(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime);

        rigidBody.AddForce((new Vector3(movementVector.x, 0, movementVector.y)));

    }
}
