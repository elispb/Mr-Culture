using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BounceAI : MonoBehaviour
{

    public float moveForce = 3f;
    public float maxSpeed = 3f;
    public GameObject player;

    private bool left;
    private Rigidbody2D rb2d;
    private float restartDelay = 0f;
    private Transform initaialPosition;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        //initaialPosition.position = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (left)
        {
            rb2d.AddForce(Vector2.left * moveForce);
        }
        else
        {
            rb2d.AddForce(Vector2.right * moveForce);
        }
        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
        {
            if (left)
            {
                rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
            }
            else
            {
                rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
            }
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //AudioClip death = other.gameObject.GetComponent<AudioClip>();
            //other.gameObject.GetComponent<AudioSource>().PlayOneShot(death);
            Invoke("Restart", restartDelay);
        }
        else
        {
            if (other.transform.position.x > transform.position.x)
            {
                rb2d.AddForce(Vector2.left * maxSpeed);
                left = true;
            }
            else if (other.transform.position.x < transform.position.x)
            {
                rb2d.AddForce(Vector2.right * maxSpeed);
                left = false;
            }
        }

    }

    void Restart()
    {
        SceneManager.LoadScene("Scene1");
        //player.transform.position = initaialPosition.position;
        //player.transform.localScale.Set(1.2f, 1.2f, 1.2f);
        //player.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 0);
        //player.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 0);
        //player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 0);
        //player.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 0);
    }
}
