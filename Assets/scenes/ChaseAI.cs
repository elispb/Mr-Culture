using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChaseAI : MonoBehaviour
{

    public float moveForce = 365f;
    public float maxSpeed = 6f;

    private Rigidbody2D rb2d;

    public GameObject player;
    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (player.transform.position.x > transform.position.x)
        {
            if (1 * rb2d.velocity.x < maxSpeed)
            {
                rb2d.AddForce(Vector2.right * 1 * moveForce);
            }
        }
        else
        {
            if (-1 * rb2d.velocity.x < maxSpeed)
            {
                rb2d.AddForce(Vector2.right * -1 * moveForce);
            }
        }

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x * maxSpeed, rb2d.velocity.y);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioClip death = other.gameObject.GetComponent<AudioClip>();
            other.gameObject.GetComponent<AudioSource>().PlayOneShot(death);
            SceneManager.LoadScene("Scene1");
        }

    }
}
