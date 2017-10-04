using System.Collections;
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
    public int score = 0;
    public int health = 0;

    /* Private */
    private Completed_IntermItemBehaviour item;

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
                    health += item.GetItemProperty();
                    break;
                case Completed_IntermItemTypes.item_score:
                    score += item.GetItemProperty();
                    break;
            }

            Destroy(other.gameObject);
        }
    }
}
