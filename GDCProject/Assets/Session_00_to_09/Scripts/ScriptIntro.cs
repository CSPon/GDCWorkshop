using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptIntro : MonoBehaviour
{
    /* Unity divides game into five different stages; Awake, Start, Fixed Update, Update, and Late Update */

    /* Awake is called when a game object is being loaded; this is called only once at the very begining of
     * Game sequence. Use this to initialize any game objects.
     */
    private void Awake()
    {
    }

    /* Start is called after Awake() and before Update(). Just like Awake(), it is called only once.
     * This is useful when a certain game object requires other game object. Obviously, game object A cannot
     * call upon game object B until game object B is initialized; which means, game object B is initialized
     * in Awake(), then game object A can initialize itself on Start() by calling game object B. Once Start()
     * is called, game moves onto continuous sequence of updates.
     */
    private void Start()
    {
    }

    /* FixedUpdate() is the very first function that is called while game is in play. Unlike Update() or LateUpdate(),
     * FixedUpdate() can be called multiple times inbetween frames; For example, if frame rate is low, FixedUpdate() may
     * be called multiple times, while FixedUpdate() may not be called even once if frame rate is high.
     * 
     * Difference between Update() and FixedUpdate() is that while Update() is called inbetween each frame, FixedUpdate()
     * is called at consistant rate. Also, after FixedUpdate(), physics calculations are made; which makes FixedUpdate()
     * useful for any physics motion update.
     */
    private void FixedUpdate()
    {
    }

    /* Update() is called upon each frame. This is the main part of our game is updated. Like stated above, Update() is
     * called every frame. Which means if our game runs at 30FPS, Update() is called 30 times per second. If our game
     * runs at 60FPS, Update() is called 60 times per second.
     */
    private void Update()
    {
    }

    /* LateUpdate() is called after Update() is called. One key example for LateUpdate() would be camera movement update,
     * after player's position is updated.
     */
    private void LateUpdate()
    {
    }
}
