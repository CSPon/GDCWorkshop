using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* UI package is not accessible unless we include it. */
using UnityEngine.UI;

/*
 * GDC Intermediate Unity
 * 
 * Displaying score
 * 
 */

[AddComponentMenu("GDC/Completed/Intermediate/GUIs/Score Display Control")]
public class Completed_IntermScoreBehaviour : MonoBehaviour
{
    /* Public */
    public Text scoreText;

    /* We have two ways to handle our score; either score script has own trigger function
     * to check if player hits trigger or not, or we can link our player's item controller
     * and save score in there.
     */
    private Completed_IntermPlayerItemBehaviour player;

    private void Awake()
    {
        player = GameObject.Find("player").GetComponent<Completed_IntermPlayerItemBehaviour>();
        player.Score = 0;
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + player.Score;
    }

    private void Start()
    {
        UpdateScore();
    }

    private void Update()
    {
        UpdateScore();
    }
}
