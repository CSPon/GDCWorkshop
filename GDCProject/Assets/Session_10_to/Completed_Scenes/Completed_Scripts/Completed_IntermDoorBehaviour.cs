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
    public bool needKey = false; /* For Scene #17 */
    public bool needAction = false; /* For Scene #19 */
    public GameObject player; /* To identify who is in trigger area */
    public AudioClip doorOpen, doorClose; /* To play open/close sound */

    /* Private */
    private Animator anim; /* To control our door animation */
    private AudioSource doorAudio; /* To play sound when door is opening/closing */
    /* This variable is for Scene #17 */
    private Completed_IntermPlayerItemBehaviour playerItem; /* To check if player has key */
    public bool triggered = false; /* For Scene #19 */
    public bool inRange = false;

    /* At the beginning, we want to get all our components to use during game.
     */
    private void Awake()
    {
        doorAudio = this.gameObject.GetComponent<AudioSource>();
        anim = this.gameObject.GetComponentInChildren<Animator>();
        playerItem = player.GetComponent<Completed_IntermPlayerItemBehaviour>();
    }

    private void Update()
    {
        CheckTrigger();
    }

    /* If player enteres trigger area, we want to play our opening animation.
     * At the same time, we want to play the audio for opening.
     * 
     * For Scene #17
     * We need to check if this door object requires key. If it does, we need to check
     * if player has key. If not the door won't open.
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            inRange = true;

            if (needAction) /* For Scene #19 */
            {
                if(triggered)
                {
                    if (needKey)
                    {
                        if (playerItem.hasKey)
                            PlayDoorOpen();
                    }
                    else PlayDoorOpen();
                }
            }
            else
            {
                if (needKey)
                {
                    if (playerItem.hasKey)
                    {
                        PlayDoorOpen();
                    }
                }
                else
                {
                    PlayDoorOpen();
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            inRange = true;

            if (needAction) /* For Scene #19 */
            {
                if (triggered)
                {
                    if (needKey)
                    {
                        if (playerItem.hasKey)
                            PlayDoorOpen();
                    }
                    else PlayDoorOpen();
                }
            }
            else
            {
                if (needKey)
                {
                    if (playerItem.hasKey)
                    {
                        PlayDoorOpen();
                    }
                }
                else
                {
                    PlayDoorOpen();
                }
            }
        }
    }

    /* If player exits the door trigger area, we want to play our closing animation and
     * closing sound. For this, we don't need to check key.
     */
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            triggered = false;
            inRange = false;
            PlayDoorClose();
        }
    }

    private void CheckTrigger()
    {
        if (Input.GetKeyUp("f") && inRange)
        {
            triggered = true;
        }
    }

    private void PlayDoorOpen()
    {
        anim.SetBool("isOpen", true);

        doorAudio.clip = doorOpen;
        doorAudio.Play();
    }

    private void PlayDoorClose()
    {
        anim.SetBool("isOpen", false);

        doorAudio.clip = doorClose;
        doorAudio.Play();
    }
}
