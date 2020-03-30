using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public float jumpHeight;
    public Rigidbody objectRigidBody;

    

    void Start()
    {

        objectRigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        if (!IsGrounded())
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            objectRigidBody.AddForce(new Vector3(0, jumpHeight, 0));

        }

    }

    public bool IsGrounded()
    {

        return Physics.Raycast(transform.position, Vector3.down, 1);

    }
}
