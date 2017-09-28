using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intermediate Unity
 * 
 * Player Controller
 * 
 */

[AddComponentMenu("GDC/Intermediate/Player/Player Movement")]
public class IntermPlayerBehaviour : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float jumpForce = 100.0f;

    private Rigidbody body;
    private bool inAir = false;
    private Vector3 playerPos;

    private void Awake()
    {
        body = this.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CheckMove();
        CheckJump();
    }

    private void CheckMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        playerPos = this.transform.position;

        Vector3 offset = new Vector3(horizontal * movementSpeed, 0, vertical * movementSpeed);

        Vector3 newPlayerPos = Vector3.Lerp(playerPos, playerPos + offset, Time.deltaTime);

        this.transform.position = newPlayerPos;
    }

    private void CheckJump()
    {
        if (Input.GetKeyUp("space") && !inAir)
            body.AddForce(Vector3.up * jumpForce);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
            if (inAir)
                inAir = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
            if (!inAir)
                inAir = true;
    }
}
