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


        MovePlayer(horizontal, 0f, vertical);

    }

    public void MovePlayer(float x, float y, float z)
    {
        rigidBody.AddForce(new Vector3(x * speed * Time.deltaTime, y * speed * Time.deltaTime, z * speed * Time.deltaTime));
    }
}
