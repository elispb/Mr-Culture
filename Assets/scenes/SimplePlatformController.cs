using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimplePlatformController : MonoBehaviour
{
    [HideInInspector] public bool facingright = true;
    [HideInInspector] public bool jump = false;

    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public Transform groundCheck;
    public AudioClip death;

    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;
    private float restartDelay = 1.5f;
    private bool dead = false;
    private Transform initaialPosition;

    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        //initaialPosition.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
        if (maxSpeed < 5f)
            maxSpeed /= 0.99f;

        if (Input.GetKey("escape"))
            Application.Quit();


    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rb2d.velocity.x < maxSpeed)
        {
            rb2d.AddForce(Vector2.right * h * moveForce);
        }
        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
        }
        if (h > 0 && !facingright)
        {
            Flip();
        }
        else if (h < 0 && facingright)
        {
            Flip();
        }
        if (jump)
        {
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }

        if (transform.localScale.y < 0.1f && !dead)
        {
            dead = true;
            GetComponent<AudioSource>().PlayOneShot(death);
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("Scene1");
        //transform.position = initaialPosition.position;
        //transform.localScale.Set(1.2f, 1.2f, 1.2f);
        //rb2d.AddForce(Vector2.right * 0);
        //rb2d.AddForce(Vector2.left * 0);
        //rb2d.AddForce(Vector2.up * 0);
        //rb2d.AddForce(Vector2.down * 0);
    }

    void Flip()
    {
        facingright = !facingright;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;


    }
}
