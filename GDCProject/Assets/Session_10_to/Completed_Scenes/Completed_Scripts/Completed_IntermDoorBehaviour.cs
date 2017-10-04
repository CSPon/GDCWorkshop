using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intermediate Unity
 * 
 * Door Controller
 * 
 */

[AddComponentMenu("GDC/Completed/Intermediate/Props/Automatic Door")]
public class Completed_IntermDoorBehaviour : MonoBehaviour
{
    /* Public */
    public bool needKey = false;
    public GameObject player;
    public AudioClip doorOpen, doorClose;

    /* Private */
    private Animator anim;
    private AudioSource doorAudio;
    private Completed_IntermPlayerItemBehaviour playerItem;

    private void Awake()
    {
        doorAudio = this.gameObject.GetComponent<AudioSource>();
        anim = this.gameObject.GetComponentInChildren<Animator>();
        playerItem = player.GetComponent<Completed_IntermPlayerItemBehaviour>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if(needKey)
            {
                if(playerItem.hasKey)
                {
                    anim.SetBool("isOpen", true);

                    doorAudio.clip = doorOpen;
                    doorAudio.Play();
                }
            }
            else
            {
                anim.SetBool("isOpen", true);

                doorAudio.clip = doorOpen;
                doorAudio.Play();
            }
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
