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
    private float minValue = 20;
    private float maxValue = 600;
    public float decreaseRate = 1;

    public float decreaseInterval = 0.5f;
    private float counter = 0;

    private Transform bar;

    private void Awake()
    {
        bar = this.transform;
    }

    private void UpdateBar()
    {
        Vector3 scale = bar.localScale;
        scale.x -= decreaseRate;

        if(scale.x > minValue)
            bar.localScale = scale;
        else
        {
            scale.x = minValue;
            bar.localScale = scale;
        }
    }

    private void Update()
    {
        if (counter > decreaseInterval)
        {
            UpdateBar();
            counter = 0;
        }
        else counter += Time.deltaTime;
    }
}
