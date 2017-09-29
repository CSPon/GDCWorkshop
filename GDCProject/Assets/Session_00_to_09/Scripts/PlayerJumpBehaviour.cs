using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intro to Unity
 * 
 * Applying jumping to player
 * 
 */

[AddComponentMenu("GDC/Intro/Character/Player Jump")]
public class PlayerJumpBehaviour : MonoBehaviour
{
    /* Public */
    [Range(250.0f, 1000.0f)]
    public float force_jump = 250.0f;

    /* Private */
    private Rigidbody body;
    private bool jumped = false;

    private void Awake()
    {
        /* Just like we applied force to our rigidbody to roll the player, we will apply
         * force upward to make our player jump
         */
        body = this.transform.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyUp("space") && !jumped)
        {
            /* Instead of applying force relative to player itself, we apply force relative to our world. This
             * will allow constant application of upward force on our player.
             */
            body.AddForce(Vector3.up * force_jump);
        }
    }

    /* Notice, without collision detection, our player jumps infinitely. We need to add jump flag so our player will
     * jump only when it is on the ground.
     * 
     * We use collision detection for this. There are three collision detection available;
     * OnCollisionEnter(), OnCollisionStay(), and OnCollisionExit().
     * 
     * OnCollisionEnter() is triggered when a game object enters collision state with other game object.
     * OnCollisionStay() is triggered when a game object maintains collision state with other game object.
     * OnCollisionExit() is triggered when a game object exits collision state with other game object.
     * 
     * Note that you can only get one collision at a time; that is, if two ore more game objects are colliding with 
     * a game object, only one is registered. However, it will iterate through game objects.
     * 
     * So, how can we use these for our jumping player?
     * 
     * While player is on the ground, we want to check if player has jumped or not. For this, we want to check if player
     * is making constant collision with our world. We use OnCollisionStay() for this.
     * 
     * While player is in the air, we want to disable jump until player lands back to ground. At first, we think we can
     * use OnCollisionEnter(), and check if ball enetered collision state with ground. But to think again, while our player
     * is in the air, our jump flag is still at false, because there was no check if player is in the air.
     * 
     * So to set our jump flag, we check if our player left collision with ground. If that is the case, it means player is
     * in the air, which allows us to set our jump flag to true. From here, we keep our jump state until player comes back
     * down and makes steady collision with ground.
     * 
     * Below is simplified state-machine table for our player jump.
     * 
     * Current State -> Collision    -> Next State
     *    Not Jumped    Collision       Not Jumped
     *    Not Jumped    No Collision    Jumped
     * -------------------------------------------
     *        Jumped    No Collision    Jumped
     *        Jumped    Collision       Not Jumped
     * 
     */
    private void OnCollisionEnter(Collision collision)
    {
        /* No code. We are not using OnCollisionEnter()
         */
    }
    private void OnCollisionStay(Collision collision)
    {
        /* We first want to check if we are colliding with proper game object; our ground.
         * Next, we check if out state is in jump state. If we are still in jump state, we change our state into not jumped.
         */
        if (collision.collider.gameObject.layer == 9 && collision.collider.gameObject.tag.Equals("Ground"))
            if (jumped)
                jumped = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        /* Similar to OnCollisionStay(), we check if we left our ground. Then we check if our jump state is still in not jumped.
         * From there, we change our jump state to true.
         */
        if (collision.collider.gameObject.layer == 9 && collision.collider.gameObject.tag.Equals("Ground"))
            if (!jumped)
                jumped = true;
    }
}
