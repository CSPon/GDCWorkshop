using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Charlie/Intro/Player/Player Jump")]
public class PlayerJumpBehaviour : MonoBehaviour
{
    [Range(250.0f, 1000.0f)]
    public float jumpForce = 250.0f;

    private Rigidbody body;
    private bool jumped = false;

    private void Awake()
    {
        body = this.gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(Input.GetKeyUp("space") && !jumped)
        {
            body.AddForce(Vector3.up * jumpForce);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.layer == 9 && collision.collider.gameObject.tag.Equals("Ground"))
            if (jumped)
                jumped = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.layer == 9 && collision.collider.gameObject.tag.Equals("Ground"))
            if (!jumped)
                jumped = true;
    }
}
