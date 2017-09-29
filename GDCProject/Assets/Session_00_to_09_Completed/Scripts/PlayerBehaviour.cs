using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intro to Unity
 * 
 * Combining Player Inputs
 * 
 * Let's combine our player's movement into one script so we can manage them all-in-one.
 * 
 */

[AddComponentMenu("GDC/Intro/Character/Player Movement")]
public class PlayerBehaviour : MonoBehaviour
{
    /* Public */
    [Range(5.0f, 10.0f)]
    public float forceMove = 5.0f;

    [Range(250.0f, 1000.0f)]
    public float forceJump = 250.0f;

    public bool allowMoveInAir = true;
    public int score = 0;

    /* Private */
    private Rigidbody body;
    private Vector3 force;
    private bool jumped;

    private AudioSource itemPicked;

    private void Awake()
    {
        body = this.gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        /* We splited our one big function into smaller function, because Object-Oriented is convenient!
         */
        JumpPlayer();
        MovePlayer();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.layer == 9 && collision.collider.gameObject.tag.Equals("Ground"))
            if (jumped)
                jumped = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.layer == 9 && collision.collider.gameObject.tag.Equals("Ground"))
            if (!jumped)
                jumped = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8 && (other.gameObject.tag.Equals("Item_Score") || other.gameObject.tag.Equals("Item_Damage")))
        {
            ItemBehaviour item = other.gameObject.GetComponent<ItemBehaviour>();

            /* Part 9: To use with item interaction
             */
            MeshRenderer renderer = other.gameObject.GetComponent<MeshRenderer>();

            /* Part 9: Retrieve sound source from our item game object
             */
            itemPicked = other.gameObject.GetComponent<AudioSource>();


            score += item.GetScoreAmount();

            /* Part 9: Then we play the sound before we destory
             */
            itemPicked.PlayOneShot(itemPicked.clip);

            /* Part 9: Here is the problem; if we destory our game object immediately from the world, soud source which item
             * game object was holding will be destroyed as well, resulting sound not being played. To avoid this,
             * we give a delay to our Destroy.
             * 
             * But if we give delay, our item is still visible and interactable. How can we fix this?
             * Before we call our Destroy(), we 'disable' our item game object. That way, item game object is 'hidden' from
             * world, and can be destoryed after.
             */
            renderer.enabled = false;
            other.enabled = false;

            Destroy(other.gameObject, itemPicked.clip.length);
        }
    }

    private void MovePlayer()
    {
        float force_horizontal = Input.GetAxis("Horizontal");
        float force_vertical = Input.GetAxis("Vertical");

        force = new Vector3(force_horizontal * forceMove, 0, force_vertical * forceMove);

        /* We want to have an option where we want to be able to move our player while the player is in the air.
         */
        if(!jumped || allowMoveInAir)
            body.AddForce(force);
    }

    private void JumpPlayer()
    {
        if (Input.GetKeyUp("space") && !jumped)
        {
            body.AddForce(Vector3.up * forceJump);
        }
    }
}
