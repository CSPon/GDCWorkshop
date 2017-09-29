using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intro to Unity
 * 
 * Camera Movement (By searching)
 * 
 */

[AddComponentMenu("GDC/Intro/Camera/Camera Movement B")]
public class CameraSearchBehaviour : MonoBehaviour
{
    /* For previous example, we had to link our object from editor level.
     * But what if we want to 'search' our player instead of manually
     * linking?
     */
    private Transform target_object;

    private Vector3 offset, player_pos, camera_pos;

    private void Awake()
    {
        /* We set our fixed offset for camera
         */
        offset = new Vector3(0, 10, -10);

        /* Remember the tags we created from 01? Its time to use it.
         * So we set tag for our player game object as 'Player'. We can now search
         * our player game object by tag.
         */
        target_object = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        player_pos = target_object.position;

        camera_pos = player_pos + offset;

        this.transform.position = camera_pos;
    }
}
