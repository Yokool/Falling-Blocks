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
        Jump thisJump = GetComponent<Jump>();

        ShopSaveSystem.SerializedJump.PopulateScript(thisJump);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PerformJump();
        }

    }

    public void PerformJump()
    {
        if (!IsGrounded())
        {
            return;
        }

        objectRigidBody.AddForce(new Vector3(0, jumpHeight, 0));
        AudioManager.INSTANCE.PlaySound(SoundDatabase.JumpSFX);
    }

    public bool IsGrounded()
    {

        return Physics.Raycast(transform.position, Vector3.down, 1);

    }
}
