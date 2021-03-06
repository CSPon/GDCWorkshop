﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intermediate Unity
 * 
 * Spawn-able bullet
 * 
 */

[AddComponentMenu("GDC/Completed/Intermediate/Props/Bullet")]
public class Completed_IntermBulletBehaviour : MonoBehaviour
{
    public float speed = 10.0f;

    private Rigidbody body;

    private void Awake()
    {
        body = this.gameObject.GetComponent<Rigidbody>();
    }

    /* We this bullet gets instantiated, we want to define velocity for our
     * bullet.
     */
    private void Start()
    {
        body.velocity = this.transform.forward * speed;
    }

    /* If this bullet hits anything, we will simply destory
     */
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
