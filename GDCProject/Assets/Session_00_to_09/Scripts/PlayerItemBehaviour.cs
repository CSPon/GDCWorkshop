using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intro to Unity
 * 
 * Interacting with items
 * 
 */

[AddComponentMenu("GDC/Intro/Character/Item Interaction")]
public class PlayerItemBehaviour : MonoBehaviour
{
    /* Public */
    public int score = 0;

    /* Before we get into writing scripts, let's look at our options for items.
     * Note that we changed our items' collider as trigger; this means our item does not have
     * any rigidbody property like our player game object does; it allows other game objects
     * to collide with itself, but its collision state is acquired as trigger.
     * 
     * There are three available functions for triggers;
     * OnTriggerEnter(), OnTriggerStay(), and OnTriggerExit().
     * 
     * Similar to Collision detection, OnTriggerEnter() is called when game object collides with other game object
     * and that other game object is trigger.
     */
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8 && (other.gameObject.tag.Equals("Item_Score") || other.gameObject.tag.Equals("Item_Damage")))
        {
            ItemBehaviour item = other.gameObject.GetComponent<ItemBehaviour>();

            score += item.GetScoreAmount();

            Destroy(other.gameObject);
        }
    }
}
