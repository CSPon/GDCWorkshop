using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intro to Unity
 * 
 * Camera Movement with Rotation B
 * 
 */

[AddComponentMenu("GDC/Completed/Intro/Camera/Camera Move And Rotate B")]
public class Completed_FinalCameraBehaviour : MonoBehaviour
{
    /* Previous example used six keys to move and rotate.
     * Let's move our rotation to mouse movement.
     */

    /* Private */
    private Transform target_object;
    private Vector3 offset, player_pos, camera_pos;

    private void Awake()
    {
        offset = new Vector3(0, 6, -6);
        target_object = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        /* This time, we get our horizontal mouse movement
         */
        float rotation = Input.GetAxis("Mouse X");

        offset = Quaternion.AngleAxis(rotation, Vector3.up) * offset;
    }

    private void LateUpdate()
    {
        player_pos = target_object.position;

        camera_pos = player_pos + offset;

        this.transform.position = camera_pos;
        this.transform.LookAt(target_object);
    }
}
