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
public class Completed_IntermAutoDoorBehaviour : MonoBehaviour
{
    /* Public */
    public GameObject player;
    public AudioClip doorOpen, doorClose;
    /* For Scene #17 */
    public bool requireKey = false;
    /* For Scene #19 */
    public bool requireAction = false;

    /* Private */
    private Animator anim;
    private AudioSource doorAudio;
    private int counter = 0;
    /* For Scene #17 */
    private Completed_IntermPlayerItemBehaviour playerItem;

    private void Awake()
    {
        anim = this.gameObject.GetComponentInChildren<Animator>();
        doorAudio = this.gameObject.GetComponent<AudioSource>();

        /* For Scene #17 */
        playerItem = player.GetComponent<Completed_IntermPlayerItemBehaviour>();
    }

    /* When player enters door trigger, we need to check if is player.
     * Instead of directly playing animation, we will add counter.
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if(!requireAction) /* Skip until Scene #19 */
            {
                if (requireKey) /* Skip until Scene #17 */
                {
                    if (playerItem.hasKey)
                        counter++;
                }
                else
                    counter++;
            }
        }
    }

    /* Instead of subtracting directly, we will check maximum value between
     * zero and counter - 1.
     */
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
            counter = Mathf.Max(0, counter - 1);
    }

    /* For Scene #19 */
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player)
        {
            if (requireAction)
            {
                if (Input.GetKeyUp("f"))
                {
                    if (requireKey)
                    {
                        if (playerItem.hasKey)
                            counter++;
                    }
                    else counter = 1;
                }
            }
            else counter = 1;
        }
    }

    /* If counter is positive, we will play animation.
     */
    private void Update()
    {
        anim.SetBool("isOpen", counter > 0);

        if(anim.IsInTransition(0) && !doorAudio.isPlaying)
        {
            if(anim.GetBool("isOpen"))
            {
                doorAudio.clip = doorOpen;
                doorAudio.Play();
            }
            else
            {
                doorAudio.clip = doorClose;
                doorAudio.Play();
            }
        }
    }
}
