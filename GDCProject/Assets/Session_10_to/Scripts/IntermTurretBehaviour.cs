using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intermediate Unity
 * 
 * Turret Controller
 * 
 */

[AddComponentMenu("GDC/Intermediate/Props/Turret Controller")]
public class IntermTurretBehaviour : MonoBehaviour
{
    public Transform player;
    public float smoothness = 1.5f;
    public Transform muzzlePoint;
    public Transform pivot;

    private Vector3 relPos;
    private Animator anim;

    private void Awake()
    {
        anim = this.gameObject.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (anim.GetBool("hasTarget") && CanSee())
        {
            anim.enabled = false;
            LookAt();
        }
        else
        {
            anim.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            relPos = player.position - muzzlePoint.position;
            if (CanSee())
            {
                anim.SetBool("hasTarget", true);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform == player)
        {
            relPos = player.position - muzzlePoint.position;
            anim.SetBool("hasTarget", CanSee());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("hasTarget", false);
    }

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
}
