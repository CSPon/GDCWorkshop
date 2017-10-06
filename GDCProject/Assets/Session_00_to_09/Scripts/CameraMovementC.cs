using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Charlie/Intro/Camera/Camera Move and Rotate A")]
public class CameraMovementC : MonoBehaviour
{
    [Range(1.0f, 10.0f)]
    public float rotationSpeed = 1.0f;

    private Transform targetObject;
    private Vector3 offset, playerPos, cameraPos;

    private void Awake()
    {
        offset = new Vector3(0, 6, -6);

        targetObject = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float rotate = Input.GetAxis("Center");

        offset = Quaternion.AngleAxis(rotationSpeed * rotate, Vector3.up) * offset;
    }

    private void LateUpdate()
    {
        playerPos = targetObject.position;
        cameraPos = playerPos + offset;

        this.transform.position = cameraPos;
        this.transform.LookAt(targetObject);
    }
}
