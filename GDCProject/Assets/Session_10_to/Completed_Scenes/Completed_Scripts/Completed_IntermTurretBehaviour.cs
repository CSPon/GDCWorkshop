using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intermediate Unity
 * 
 * Turret Controller
 * 
 */

[AddComponentMenu("GDC/Completed/Intermediate/Props/Turret Animation Controller")]
public class Completed_IntermTurretBehaviour : MonoBehaviour
{
    /* Public */
    public Transform player;
    public float smoothness = 1.5f;
    public Transform muzzlePoint;
    public Transform pivot;

    /* Private */
    private Vector3 relPos;
    private Animator anim;
    private bool hasTarget;

    private void Awake()
    {
        anim = this.gameObject.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        /* If we have target(our player), turret should face its muzzle towards player.
         */
        if (hasTarget)
            LookAt();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            /* If our player enters turret's detection range, we update player's position.
             * From there, we calcalate relative vector by subtracting player's position to
             * muzzle.
             */
            relPos = player.position - muzzlePoint.position;
            if (CanSee())
            {
                hasTarget = true;
                anim.enabled = false;
                anim.SetBool("hasTarget", true);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform == player)
        {
            /* If player remains inside turret's detection range, we constantly update our player's
             * position.
             */
            if(!hasTarget)
                hasTarget = true;
            if(anim.enabled)
                anim.enabled = false;
            relPos = player.position - muzzlePoint.position;
            anim.SetBool("hasTarget", CanSee());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("hasTarget", false);
        hasTarget = false;
        anim.enabled = true;
    }

    /* Similar to RaycastHit from camera movement, turret will shoot an invisible ray towards player.
     * If it hits player, that means turret has clear line of sight to player.
     */
    private bool CanSee()
    {
        RaycastHit hit;

        float distance = relPos.magnitude;

        if(Physics.Raycast(muzzlePoint.position, player.position - muzzlePoint.position, out hit, distance))
        {
            if (hit.transform == player)
                return true;
        }

        return false;
    }

    private void LookAt()
    {
        relPos = player.position - muzzlePoint.position;
        Quaternion lookAtRotation = Quaternion.LookRotation(relPos, Vector3.up);

        pivot.rotation = Quaternion.Lerp(pivot.rotation, lookAtRotation, smoothness * Time.deltaTime);
    }

    public bool HasTarget()
    {
        return hasTarget;
    }
}
