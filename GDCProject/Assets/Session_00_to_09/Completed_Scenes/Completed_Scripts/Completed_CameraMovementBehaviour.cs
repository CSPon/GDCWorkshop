using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intro to Unity
 * 
 * Camera Movement with Rotation A
 * 
 */

[AddComponentMenu("GDC/Completed/Intro/Camera/Camera Move And Rotate A")]
public class Completed_CameraMovementBehaviour : MonoBehaviour
{
    /* Public */
    [Range(1.0f, 10.0f)]
    public float rotation_speed = 1.0f;

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
        float rotation = Input.GetAxis("Center");

        offset = Quaternion.AngleAxis(rotation * rotation_speed, Vector3.up) * offset;
    }

    private void LateUpdate()
    {
        player_pos = target_object.position;

        camera_pos = player_pos + offset;

        this.transform.position = camera_pos;
        this.transform.LookAt(target_object);
    }
}
