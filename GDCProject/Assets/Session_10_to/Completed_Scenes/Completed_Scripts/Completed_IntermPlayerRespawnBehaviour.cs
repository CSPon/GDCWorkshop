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
    /* Private */
    private Transform player;
    private Vector3 current_respawn_pos;

    /* On awake, we want to have reference to our player.
     * At the beginning of the game, since player has not yet entered any invisible
     * respawn zone, we will set initial respawn position to player's starting position.
     */
    private void Awake()
    {
        player = GameObject.Find("player").transform;
        current_respawn_pos = GameObject.Find("player").transform.position;
    }

    /* Since bullet itself is collision-based collider, we need to use OnCollisionEnter().
     * If player collides with bullet or any damage item, player will be forced to respawn
     * position.
     */
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Item_Damage"))
        {
            player.position = current_respawn_pos;
        }
    }

    /* When player enters respawn trigger area, we want to update respawn position. Since
     * all respawn zones are trigger-based collider, we will include this in OnTriggerEnter().
     * At the same time, since we have pitfalls as trigger-based collider as well, we will
     * check pitfall in OnTriggerEnter() as well.
     */
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
