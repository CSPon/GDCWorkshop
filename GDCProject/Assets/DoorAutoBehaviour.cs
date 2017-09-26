using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAutoBehaviour : MonoBehaviour
{
    public GameObject player;

    private Animator anim;

    private void Awake()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
            anim.SetBool("isOpen", true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
            anim.SetBool("isOpen", false);
    }
}
