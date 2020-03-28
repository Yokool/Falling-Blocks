using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public float jumpHeight;
    public Rigidbody objectRigidBody;

    private bool OnGround
    {
        get;
        set;
    }

    void Start()
    {

        objectRigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        if (!OnGround)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnGround = false;
            objectRigidBody.AddForce(new Vector3(0, jumpHeight, 0));

        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag.Equals("BreakableT"))
        {
            OnGround = true;
        }

    }
}
