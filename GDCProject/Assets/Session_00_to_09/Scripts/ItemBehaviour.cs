using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intro to Unity
 * 
 * Creating pick-up items
 * 
 */

[AddComponentMenu("GDC/Props/Item Properties")]
public class ItemBehaviour : MonoBehaviour
{
    /* Public */
    public int scoreAmount = 1;

    /* Private */
    private float rotate_speed = 30.0f;

    private void LateUpdate()
    {
        /* We want to have our item rotate, emphasizing itself as an item.
         * Problem is, our local axis is tilted, meaning it won't rotate the way we want.
         * To fix this, at the end of Rotate(), we add Space.World, letting Unity know we want to
         * rotate our object relative to World's axis.
         */
        this.transform.Rotate(Vector3.up, rotate_speed * Time.deltaTime, Space.World);
    }

    /* We would like to get the amount of score each item can give/take from player. Hence why
     * we need to create getter function of our scoreAmount variable.
     */
    public int GetScoreAmount()
    {
        return scoreAmount;
    }
}

/* After we apply this script to our item game object, we will create couple more around the map.
 * We do this by creating Prefab. Think of prefab is shorten name for Pre-Fabricated. Once a game object
 * is pre-fabricated, you can make multiple copies of same game object without creating same object
 * one at a time.
 */
