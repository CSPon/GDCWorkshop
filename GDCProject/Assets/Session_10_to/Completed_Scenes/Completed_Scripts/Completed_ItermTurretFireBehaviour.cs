using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intermediate Unity
 * 
 * Turret Fire Controller
 * 
 */

[AddComponentMenu("GDC/Completed/Intermediate/Props/Turret Fire Controller")]
public class Completed_ItermTurretFireBehaviour : MonoBehaviour
{
    /* Public */
    public GameObject bullet;
    public Transform muzzlePoint;
    public float fireRate = 5.0f;

    /* Private */
    private float nextShot;
    private Completed_IntermTurretBehaviour turret;
    private AudioSource sfx;

    private void Awake()
    {
        /* Since we want to get status of locking onto player, we get
         * IternmTurretBehaviour script object from our turret game object.
         */
        turret = this.gameObject.GetComponent<Completed_IntermTurretBehaviour>();
        sfx = this.gameObject.GetComponent<AudioSource>();
    }

    /* While turrent has target, we check if our next shot timer is greater than
     * our fire rate. If next shot timer is greater than fire rate, we fire a
     * bullet, play a sound effect, then reset our next shot timer to zero so
     * it can count next shot. However, since we do not want to have any overflow
     * error on float variable, we will add timer only and only if turret has
     * target.
     */
    private void Update()
    {
        if (turret.HasTarget())
        {
            if(nextShot > fireRate)
            {
                Instantiate(bullet, muzzlePoint.position, muzzlePoint.rotation);
                sfx.Play();
                nextShot = 0;
            }
            else nextShot += Time.deltaTime;
        }
    }
}
