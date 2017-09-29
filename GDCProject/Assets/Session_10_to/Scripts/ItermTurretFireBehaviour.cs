using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intermediate Unity
 * 
 * Turret Fire Controller
 * 
 */

[AddComponentMenu("GDC/Intermediate/Props/Turret Fire Controller")]
public class ItermTurretFireBehaviour : MonoBehaviour
{
    public GameObject bullet;
    public Transform muzzlePoint;
    public float fireRate = 5.0f;

    private float nextShot;
    private IntermTurretBehaviour turret;

    private void Awake()
    {
        turret = this.gameObject.GetComponent<IntermTurretBehaviour>();
    }

    private void Update()
    {
        if(turret.HasTarget() && nextShot > fireRate)
        {
            Instantiate(bullet, muzzlePoint.position, muzzlePoint.rotation);
            nextShot = 0;
        }
        nextShot += Time.deltaTime;
    }
}
