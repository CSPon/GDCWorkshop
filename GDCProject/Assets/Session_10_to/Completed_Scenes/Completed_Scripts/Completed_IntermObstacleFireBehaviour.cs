using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intermediate Unity
 * 
 * Defining shooting position for obstacles
 * 
 */

[AddComponentMenu("GDC/Completed/Intermediate/Props/Obstacle Shooting")]
public class Completed_IntermObstacleFireBehaviour : MonoBehaviour
{
    /* Public */
    [Range(0.5f, 2.0f)]
    public float interval = 0.5f;
    public GameObject obstacle;

    /* Private */
    private Transform shootPosition;
    private float nextShot = 0;

    private void Awake()
    {
        shootPosition = this.transform;
    }

    /* Same as turret's shooting behaviour, we will instantiate obstacles between
     * intervals.
     */
    private void Update()
    {
        if (nextShot > interval)
        {
            nextShot = 0;
            Instantiate(obstacle, shootPosition.position, shootPosition.rotation);
        }
        else
            nextShot += Time.deltaTime;
    }
}
