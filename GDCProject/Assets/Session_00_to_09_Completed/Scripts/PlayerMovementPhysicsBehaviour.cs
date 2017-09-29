using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intro to Unity
 * 
 * Moving object by force
 * 
 */

[AddComponentMenu("GDC/Intro/Character/Move By Physics")]
public class PlayerMovementPhysicsBehaviour : MonoBehaviour
{
    /* Instead of setting how fast do we want to move(velocity), we now set how hard do we want to add
     * force to our rigidbody. So we change our variable name to force_applied.
     */
    [Range(1.0f, 10.0f)]
    public float force_applied = 1.0f;

    /* In order to access public functions within Rigidbody object, we need to get instantiated object
     * from our game object; which means we need a variable that saves Rigidbody object.
     */
    private Rigidbody body;

    private void Awake()
    {
        /* Link the instantiated rigidbody object
         */
        body = this.GetComponent<Rigidbody>();
    }

    /* Remember, we are applying physical force to our player. Which means it is more efficient to use
     * FixedUpdate()
     */
    private void FixedUpdate()
    {
        /* Same as move by translate, we get our inputs
         */
        float force_horizontal = Input.GetAxis("Horizontal");
        float force_vertical = Input.GetAxis("Vertical");

        /* Then we create 3D vector consist of total force applied to our player.
         */
        Vector3 force = new Vector3(force_horizontal * force_applied, 0, force_vertical * force_applied);

        /* Then apply the force to the rigidbody.
         */
        body.AddForce(force);

        /* We now see benefits of using ridigbody and AddForce(); collision check is much more realistic;
         * we don't have to worry about our player flying out from the map. Friction is applied to our
         * player as well, allowing more smoother control over the player. However, since our player is
         * 'rotating', our player's axis is not fixed; resulting unwanted behaviour in case we want to
         * do certain actions that requires fixed axis, such as shooting or tracking.
         */
    }
}
