using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intermediate Unity
 * 
 * Spawn-able obstacles
 * 
 */

[AddComponentMenu("GDC/Completed/Intermediate/Props/Obstacles")]
public class Completed_IntermObstacleBehaviour : MonoBehaviour
{
    private float speed;
    private Rigidbody body;

    /* Rather than giving the obstacles constant speed, we want to randomnize
     * obstacles' speed. We will use Random.Range() for this. Everything else
     * is same as bullet behaviour
     */
    private void Awake()
    {
        body = this.gameObject.GetComponent<Rigidbody>();

        speed = Random.Range(1.0f, 3.0f);
    }

    private void Start()
    {
        body.velocity = this.transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
