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

    public Color itemColor; /* To change color of item */

    /* Private */
    private float rotationSpeed = 30f; /* Rotating speed */
    private Light itemLight; /* To illuminate our item */

    /* On awake, we want to set our item's color and change item's illuminating color.
     */
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
        this.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }

    /* For player script to interact with items, we need public function to return item's
     * type.
     */
    public Completed_IntermItemTypes GetItemType()
    {
        return itemType;
    }

    /* If item is other than key type, we need to return the value for either health or score.
     */
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
