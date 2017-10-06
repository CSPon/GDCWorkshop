using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Charlie/Intro/Props/Item Behaviour")]
public class ItemBehaviour : MonoBehaviour
{
    public int scoreAmount = 0;

    private float rotateSpeed = 30.0f;

    private void LateUpdate()
    {
        this.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
    }

    public int GetScoreAmount()
    {
        return scoreAmount;
    }
}
