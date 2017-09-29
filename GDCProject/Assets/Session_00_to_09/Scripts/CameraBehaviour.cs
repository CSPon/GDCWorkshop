using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intro to Unity
 * 
 * Camera Movement (By linking)
 * 
 */

[AddComponentMenu("GDC/Intro/Camera/Camera Movement A")]
public class CameraBehaviour : MonoBehaviour
{
    /* Unity Inspector is very handy; you can set visibility of a variable as public, and
     * you can drag and drop your target game object so you can follow.
     */
    public Transform target_object;

    /* 3D Vector to save offset of camera position.
     */
    private Vector3 offset;

    private void Awake()
    {
        /* We want to offset our camera 6 units high and 6 units back.
         * Of course, we already rotated our camera by 45 degrees.
         */
        offset = new Vector3(0, 6, -6);
    }

    /* We want to update our camera position AFTER player's position is updated.
     * Hence why we use LateUpdate() here.
     */
    private void LateUpdate()
    {
        /* Get player's position
         */
        Vector3 player_pos = target_object.position;

        /* Set camera's new position by adding offset to player's position.
         */
        Vector3 camera_pos = player_pos + offset;

        /* Apply new camera position to our camera object.
         */
        this.transform.position = camera_pos;
    }
}
