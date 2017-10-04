using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intermediate Unity
 * 
 * Creating multipurpose script
 * 
 */

[AddComponentMenu("GDC/Completed/Intermediate/Props/Reusable Item")]
public class Completed_IntermItemBehaviour : MonoBehaviour
{
    /* Public */
    public Completed_IntermItemTypes itemType;
    public int healthAmount;
    public int scoreAmount;

    public Color itemColor;

    /* Private */
    private float speed = 30f;
    private Light itemLight;

    private void Awake()
    {
        itemLight = this.gameObject.GetComponent<Light>();

        this.GetComponent<Renderer>().material.color = itemColor;
        itemLight.color = itemColor;
    }

    private void Update()
    {
        AnimateRotation();
    }

    private void AnimateRotation()
    {
        this.transform.Rotate(Vector3.up, speed * Time.deltaTime, Space.World);
    }

    public Completed_IntermItemTypes GetItemType()
    {
        return itemType;
    }

    public int GetItemProperty()
    {
        switch(itemType)
        {
            case Completed_IntermItemTypes.item_health:
                return healthAmount;
            case Completed_IntermItemTypes.item_score:
                return scoreAmount;
            default:
                return 0;
        }
    }
}
