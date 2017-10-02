using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intermediate Unity
 * 
 * Respawning
 * 
 */

[AddComponentMenu("GDC/Completed/Intermediate/Player/Respawning")]
public class Completed_IntermPlayerRespawnBehaviour : MonoBehaviour
{
    private Transform player;
    private Vector3 current_respawn_pos;

    private void Awake()
    {
        player = GameObject.Find("player").transform;
        current_respawn_pos = GameObject.Find("player").transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Item_Damage"))
        {
            player.position = current_respawn_pos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            current_respawn_pos = other.transform.position;
        }
        else if (other.gameObject.CompareTag("Item_Damage"))
        {
            player.position = current_respawn_pos;
        }
    }
}
