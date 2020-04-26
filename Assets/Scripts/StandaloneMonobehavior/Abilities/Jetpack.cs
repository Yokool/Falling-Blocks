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

    public bool flying;

    void Start()
    {

        objectRigidBody = GetComponent<Rigidbody>();

        Jetpack thisJetpack = GetComponent<Jetpack>();
        ShopSaveSystem.SerializedJetpack.PopulateScript(thisJetpack);

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

        if (flying && jetpackFuel > 0)
        {
            PerformJetpackFlightTick();
        }

    }

    public void PerformJetpackFlightTick()
    {
        jetpackFuel -= jetpackSpendFuelDecrement;
        objectRigidBody.AddForce(new Vector3(0, jetpackStrength, 0));
    }


    public bool IsGrounded()
    {

        return Physics.Raycast(transform.position, Vector3.down, 1);

    }
}
