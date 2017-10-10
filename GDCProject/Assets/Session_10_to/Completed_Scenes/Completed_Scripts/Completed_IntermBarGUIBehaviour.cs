using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intermediate Unity
 *
 * Bar guage
 * 
 */

[AddComponentMenu("GDC/Completed/Intermediate/GUIs/Bar Gauge")]
public class Completed_IntermBarGUIBehaviour : MonoBehaviour
{
    public float health = 600;
    public float decreaseRate = 1;
    public float decreaseInterval = 0.5f;
    public bool isDead = false;

    private float counter = 0;
    private Transform bar;
    private Renderer barColor;
    private Color healthColor;

    private void Awake()
    {
        bar = this.transform;
        barColor = this.gameObject.GetComponentInChildren<Renderer>();

        barColor.material.color = Color.green;
    }

    private void UpdateBar()
    {
        Vector3 scale = bar.localScale;

        health -= decreaseRate;
        if (health < 0)
            isDead = true;

        healthColor = Color.Lerp(Color.red, Color.green, health / 600.0f);

        scale.x = 20 + health;

        bar.localScale = scale;
        barColor.material.color = healthColor;
    }

    private void Update()
    {
        if(!isDead)
        {
            if (counter > decreaseInterval)
            {
                UpdateBar();
                counter = 0;
            }
            else counter += Time.deltaTime;
        }
    }
}
