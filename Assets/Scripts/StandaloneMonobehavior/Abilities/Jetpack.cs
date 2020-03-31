using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{

    public Rigidbody objectRigidBody;

    public float jetpackFuel;

    public float jetpackRefuelIncrement;
    public float jetpackSpendFuelDecrement;
    public float maxFuel;

    public float jetpackStrength;

    void Start()
    {

        objectRigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        if (IsGrounded())
        {
            jetpackFuel += jetpackRefuelIncrement; // Change the values later

            if(jetpackFuel >= maxFuel)
            {
                jetpackFuel = maxFuel;
            }

            return;
        }

        if (Input.GetKey(KeyCode.Space) && jetpackFuel >= 0)
        {

            jetpackFuel -= jetpackSpendFuelDecrement; // Change the values later
            objectRigidBody.AddForce(new Vector3(0, jetpackStrength, 0)); // Change values later

        }

    }

    

    public bool IsGrounded()
    {

        return Physics.Raycast(transform.position, Vector3.down, 1);

    }
}
