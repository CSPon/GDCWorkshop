using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Charlie/Intro/Player/Player Movement Final")]
public class PlayerBehaviour : MonoBehaviour
{
    [Range(5.0f, 10.0f)]
    public float forceMove = 5.0f;
    [Range(250.0f, 1000.0f)]
    public float forceJump = 250.0f;

    public int score = 0;
    public bool allowMoveInAir = true;

    private Rigidbody body;
    private Vector3 force;
    private bool jumped;

    private AudioSource itemPicked;

    private void Awake()
    {
        body = this.gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        JumpPlayer();
        MovePlayer();
    }

    private void JumpPlayer()
    {
        if (Input.GetKeyUp("space") && !jumped)
            body.AddForce(Vector3.up * forceJump);
    }

    private void MovePlayer()
    {
        float force_horizontal = Input.GetAxis("Horizontal");
        float force_vertical = Input.GetAxis("Vertical");

        force = new Vector3(force_horizontal * forceMove, 0, force_vertical * forceMove);

        if (!jumped || allowMoveInAir)
            body.AddForce(force);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.layer == 9 && collision.collider.gameObject.tag.Equals("Ground"))
            if (jumped)
                jumped = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.layer == 9 && collision.collider.gameObject.tag.Equals("Ground"))
            if (!jumped)
                jumped = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8 && (other.gameObject.tag.Equals("Item_Score") || other.gameObject.tag.Equals("Item_Damage")))
        {
            ItemBehaviour item = other.gameObject.GetComponent<ItemBehaviour>();
            MeshRenderer mesh = other.gameObject.GetComponent<MeshRenderer>();

            itemPicked = other.gameObject.GetComponent<AudioSource>();
            score += item.GetScoreAmount();

            itemPicked.PlayOneShot(itemPicked.clip);

            mesh.enabled = false;
            other.enabled = false;

            Destroy(other.gameObject, itemPicked.clip.length);
        }
    }
}
