using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intermediate Unity
 * 
 * Moving platform
 * 
 */

[AddComponentMenu("GDC/Completed/Intermediate/Props/Moving Platform")]
public class Completed_IntermMovingPlatformBehaviour : MonoBehaviour
{
    /* Public */
    public Vector3 startPosition, endPosition; /* Start and End */

    public float delay = 2f; /* Time between moving to point */
    public float speed = 1f; /* Translation in unit per second */

    /* Private */
    private Vector3 currPos, nextPos;

    private float timer = 0;
    private float direction = 1; /* At the beginning, we want to move towards end position */
    private float tolerance = 0.1f; /* Percentage to tolerate when platform reaches next position */

    private Rigidbody body;

    private void Awake()
    {
        body = this.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        /* Move the platform to start position;
         */
        this.transform.position = startPosition;
    }

    /* In order for our platform to move our player, we need to have it as rigidbody
     * If we are using rigidbody, that means it will move smoother in FixedUpdate()
     */
    private void FixedUpdate()
    {
        currPos = this.transform.position;

        if(direction == 1)
        {
            nextPos = Vector3.Lerp(currPos, endPosition, speed * Time.deltaTime);
            body.MovePosition(nextPos);
        }
        else if(direction == -1)
        {
            nextPos = Vector3.Lerp(currPos, startPosition, speed * Time.deltaTime);
            body.MovePosition(nextPos);
        }
    }

    /* We want to check where our platform is at. Its better with regular Update() since
     * it will update faster than FixedUpdate()
     */
    private void Update()
    {
        CheckDirection();
    }

    private void CheckDirection()
    {
        if(direction == 1)
        {
            currPos = this.transform.position;
            Vector3 mag = endPosition - currPos;
            if (mag.magnitude <= tolerance)
            {
                if (timer > delay)
                {
                    direction = -1;
                    timer = 0;
                }
                else timer += Time.deltaTime;
            }
        }
        else if (direction == -1)
        {
            currPos = this.transform.position;
            Vector3 mag = startPosition - currPos;
            if (mag.magnitude <= tolerance)
            {
                if (timer > delay)
                {
                    direction = 1;
                    timer = 0;
                }
                else timer += Time.deltaTime;
            }
        }
    }
}
