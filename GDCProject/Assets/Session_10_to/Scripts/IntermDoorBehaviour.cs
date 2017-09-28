using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intermediate Unity
 * 
 * Door Controller
 * 
 */

[AddComponentMenu("GDC/Intermediate/Props/Automatic Door")]
public class IntermDoorBehaviour : MonoBehaviour
{
    public GameObject player;

    public AudioClip doorOpen, doorClose;

    private Animator anim;
    private AudioSource doorAudio;

    private void Awake()
    {
        doorAudio = this.gameObject.GetComponent<AudioSource>();
        anim = this.gameObject.GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            anim.SetBool("isOpen", true);

            doorAudio.clip = doorOpen;
            doorAudio.Play();
            //doorAudio.PlayOneShot(doorOpen);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            anim.SetBool("isOpen", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            anim.SetBool("isOpen", false);

            doorAudio.clip = doorClose;
            doorAudio.Play();
        }
    }
}
