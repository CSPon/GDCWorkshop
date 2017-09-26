using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAutoBehaviour : MonoBehaviour
{
    public GameObject player;

    public AudioClip doorOpen, doorClose;

    private Animator anim;
    private AudioSource audio;

    private void Awake()
    {
        audio = this.gameObject.GetComponent<AudioSource>();
        anim = this.gameObject.GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            anim.SetBool("isOpen", true);

            audio.PlayOneShot(doorOpen);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            anim.SetBool("isOpen", false);

            audio.PlayOneShot(doorClose);
        }
    }
}
