using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intermediate Unity
 * 
 * Camera Controller
 * 
 */

[AddComponentMenu("GDC/Completed/Intermediate/Camera/Camera Movement")]
public class Completed_IntermCameraBehaviour : MonoBehaviour
{
    /* Public */
    public float smoothness = 1.5f;

    /* Private */
    private Transform player;

    /* Instead of re-calculating relative position of camera to player, we save it at
     * the beginning, that way we can use the number during our game.
     */
    private Vector3 relCameraPos;
    private float relCameraPosMag;
    private Vector3 newPos;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        relCameraPos = transform.position - player.position;
        relCameraPosMag = relCameraPos.magnitude - 0.5f;
    }

    private void Update()
    {
        /* Upon each update, we would like to smoothly move our camera so it can follow
         * our player all the time.
         * To do this, we will sample 5 possible positions; the standard position, which,
         * our default position,
         * Above position, which, our camera is on top of our player,
         * and 3 intermeidate positions between our standard position and above position.
         * 
         * From there, we will check if our camera can see our player; if sampled position
         * can see our player, we will move our camera to that position so we can look at
         * our player.
         */
        Vector3 standardPos = player.position + relCameraPos;
        Vector3 abovePos = player.position + Vector3.up * relCameraPosMag;

        Vector3[] checkPoints = new Vector3[5];
        checkPoints[0] = standardPos;
        checkPoints[1] = Vector3.Lerp(standardPos, abovePos, 0.25f);
        checkPoints[2] = Vector3.Lerp(standardPos, abovePos, 0.5f);
        checkPoints[3] = Vector3.Lerp(standardPos, abovePos, 0.75f);
        checkPoints[4] = abovePos;

        foreach(Vector3 checkPos in checkPoints)
        {
            if (ViewingPosCheck(checkPos))
                break;
        }

        transform.position = Vector3.Lerp(transform.position, newPos, smoothness * Time.deltaTime);

        SmoothLookAt();
    }

    /* To check if our camera is looking at player or not, we will use raycast.
     * Imagine a raycast as ray coming out from starting position, and fly towards target position.
     * If ray hits an object, it will return that object's data. If ray reaches its maximum distance,
     * it will return nothing.
     */
    bool ViewingPosCheck(Vector3 checkPos)
    {
        RaycastHit hit;

        /* Physics.Raycast() returns true if ray hits an object. Alongside with boolean value, it can
         * also return what object did the ray hit (as RaycaseHit object).
         */
        if (Physics.Raycast(checkPos, player.position - checkPos, out hit, relCameraPosMag))
        {
            /* If it is not our player, return false */
            if (hit.transform != player)
                return false;
        }

        /* If ray hit our player, that means we have new position to move our camera to. So we will
         * save our new position then return true.
         */
        newPos = checkPos;
        return true;
    }

    /* Not only we want our camera to translate to new position smoothly, but we also want to rotate
     * our camera smoothly. Similar to position lerping, we will take our relative position from our
     * player to our camera, then use it to calculate rotation. From there, we can lerp our rotation.
     */
    void SmoothLookAt()
    {
        Vector3 relPlayerPosition = player.position - transform.position;
        Quaternion lookAtRotation = Quaternion.LookRotation(relPlayerPosition, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, lookAtRotation, smoothness * Time.deltaTime);
    }
}
