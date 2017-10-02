using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intermediate Unity
 * 
 * Combined Turret Controller
 * 
 */

[AddComponentMenu("GDC/Completed/Intermediate/Props/Turret Controller")]
public class Completed_ItermTurretFinalBehaviour : MonoBehaviour
{
    public GameObject bullet;
    public Transform player;
    public Transform muzzlePoint;
    public Transform pivot;

    public float fireRate = 5.0f;

    [Range(0.1f, 1.0f)]
    public float smoothness = 1.5f;

    private Vector3 relPos;
    private Animator anim;
    private bool hasTarget;

    private float nextShot;

    private AudioSource sfx;

    private void Awake()
    {
        sfx = this.gameObject.GetComponent<AudioSource>();
        anim = this.gameObject.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (hasTarget)
            LookAt();
    }

    private void LateUpdate()
    {
        if (hasTarget)
        {
            if (nextShot > fireRate)
            {
                Instantiate(bullet, muzzlePoint.position, muzzlePoint.rotation);
                sfx.Play();
                nextShot = 0;
            }
            else nextShot += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
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
            relPos = player.position - muzzlePoint.position;
            if (CanSee())
            {
                hasTarget = true;
                anim.enabled = false;
                anim.SetBool("hasTarget", true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("hasTarget", false);
        hasTarget = false;
        anim.enabled = true;
    }

    private bool CanSee()
    {
        RaycastHit hit;

        float distance = relPos.magnitude;

        if (Physics.Raycast(muzzlePoint.position, player.position - muzzlePoint.position, out hit, distance))
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
