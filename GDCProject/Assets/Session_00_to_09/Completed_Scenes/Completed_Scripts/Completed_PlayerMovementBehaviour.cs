using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * GDC Intro to Unity
 * 
 * Character Movement by translation
 * 
 */

[AddComponentMenu("GDC/Completed/Intro/Character/Move By Translate")]
public class Completed_PlayerMovementBehaviour : MonoBehaviour
{
    /* We want to adjust player's movement speed within the editor; to do so, we declare speed variable
     * as public. There are two ways of having public variables displayed in the editor; as textfield
     * or as textfield with limit slider. We will use limit slider.
     */
    [Range(1.0f, 10.0f)]
    public float player_speed = 1.0f;

    /* In order to move a character by updating position, you need player's position vector.
     * You can have it saved by declaring as variable, or can call everytime when frame is
     * updated. We will declare Vector variable.
     */
    private Vector3 player_position;

    private void Awake()
    {
        /* Set player_position vector as this game object's initial position */
        player_position = this.transform.position;
    }

    private void Update()
    {
        /* To check if player has input any movement keys, we take in key input. There are two ways of doing this.
         * One way is to get input as axis input; either X, Y, or Z axis.
         * The other way to get input is to take in iput as keyboard input.
         * For this script, we will use Input.GetAxis().
         */
        float horizontal_input = Input.GetAxis("Horizontal");
        float vertical_input = Input.GetAxis("Vertical");

        /* From here, we can calculate new X and Z position of player (We are ignoring Y axis)
         */
        //float player_x_pos = horizontal_input * player_speed;
        //float player_y_pos = 0;
        //float player_z_pos = vertical_input * player_speed;

        /* Then apply new position to player's position vector
         */
        //player_position.Set(player_x_pos, player_y_pos, player_z_pos);

        /* When we use Translate(), it means we are adding increment value to our game object's position vector.
         */
        //this.transform.Translate(player_position);

        /* By this point, we notice our character does not move the way we want; it moves too fast. This is because our
         * frame rate is high, its updating at a rate of 30~60FPS. To compensate this, we apply Time.deltaTime. DeltaTime
         * is time between each frame, allowing us to smooth out any non-physics movements. Comment out pervious player
         * position and use new code below.
         */
        float player_x_pos = horizontal_input * player_speed * Time.deltaTime;
        float player_z_pos = vertical_input * player_speed * Time.deltaTime;

        player_position.Set(player_x_pos, 0, player_z_pos);

        this.transform.Translate(player_position);
    }
}
