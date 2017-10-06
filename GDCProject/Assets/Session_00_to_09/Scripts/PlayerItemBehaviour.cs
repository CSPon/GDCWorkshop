using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Charlie/Intro/Player/Item Behaviour")]
public class PlayerItemBehaviour : MonoBehaviour
{
    public int score = 0;

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
