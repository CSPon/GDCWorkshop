using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intermediate Unity
 * 
 * Rolling AI
 * 
 */

[AddComponentMenu("GDC/Completed/Intermediate/Props/Rolling AI")]
public class Completed_IntermRollerBehaviour : MonoBehaviour
{
    /* Public */
    [Range(1.0f, 100.0f)]
    public float rollingForce = 1.0f;
    public GameObject target;

    /* Private */
    private Rigidbody body;
    private Vector3 playerPos, direction, force;
    private bool inRange;

    private void Awake()
    {
        body = this.gameObject.GetComponent<Rigidbody>();
    }

    /* While our player is within roller's detection range, we will update
     * player's position.
     */
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == target)
        {
            playerPos = other.gameObject.transform.position;
            inRange = true;
        }
    }

    /* When our player exits roller's trigger area, it will not update player's position,
     * but will set player's sight to false.
     */
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == target)
        {
            inRange = false;
        }
    }

    /* Since we want to apply rolling force towards direction of player, we normalize
     * direction by subtracting current position of roller from player's position.
     */
    private void FixedUpdate()
    {
        if(inRange)
        {
            direction = playerPos - this.transform.position;
            force = direction.normalized * rollingForce;
            body.AddForce(force);
        }
    }
}
