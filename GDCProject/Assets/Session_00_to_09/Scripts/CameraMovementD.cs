using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Charlie/Intro/Camera/Camera Move and Rotate B")]
public class CameraMovementD : MonoBehaviour
{
    private Transform targetObject;
    private Vector3 offset, player_pos, camera_pos;

    private void Awake()
    {
        targetObject = GameObject.FindGameObjectWithTag("Player").transform;
        offset = new Vector3(0, 6, -6);
    }

    private void Update()
    {
        float rotation = Input.GetAxis("Mouse X");

        offset = Quaternion.AngleAxis(rotation, Vector3.up) * offset;
    }

    private void LateUpdate()
    {
        player_pos = targetObject.position;
        camera_pos = player_pos + offset;

        this.transform.position = camera_pos;
        this.transform.LookAt(targetObject);
    }
}
