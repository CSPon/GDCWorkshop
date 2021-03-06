﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intermediate Unity
 * 
 * Player item behaviour
 * 
 */

[AddComponentMenu("GDC/Completed/Intermediate/Player/Player Item Interaction")]
public class Completed_IntermPlayerItemBehaviour : MonoBehaviour
{
    /* Public */
    public bool hasKey = false;

    /* Change after Scene #21 */
    private int score = 0;
    private int health = 0;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }
    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    /* Private */
    private Completed_IntermItemBehaviour item;

    /* All items in this project are trigger-based collider. Which means we will handle
     * all our item interactions in OnTriggerEnter(). First, we want to check
     * if colliding trigger is item. Next, we will get the type of an item and handle
     * items based on what type it is. Once handling is done, we can destroy our item
     * game object.
     */
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Item"))
        {
            item = other.gameObject.GetComponent<Completed_IntermItemBehaviour>();
            switch(item.GetItemType())
            {
                case Completed_IntermItemTypes.item_key:
                    hasKey = true; break;
                case Completed_IntermItemTypes.item_health:
                    Health = Health + item.GetItemProperty();
                    break;
                case Completed_IntermItemTypes.item_score:
                    Score = Score + item.GetItemProperty();
                    break;
            }

            Destroy(other.gameObject);
        }
    }
}
