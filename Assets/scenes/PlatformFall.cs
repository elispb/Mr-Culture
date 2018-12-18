using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : SwitchableDevice
{

    public float fallDelay = 1f;


    private Rigidbody2D rb2d;

	// Use this for initialization
	void Awake () {
        rb2d = GetComponent<Rigidbody2D>();
        isSwitchedOn = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionStay2D (Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            
            float theSpeed = other.gameObject.GetComponent<SimplePlatformController>().maxSpeed;
            if (theSpeed > 0.5f)
            {
                theSpeed *= 0.99f;
                other.gameObject.GetComponent<SimplePlatformController>().maxSpeed = theSpeed;
            }
        }
        if (!isSwitchedOn && other.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
        }
    }

    void Fall()
    {
        rb2d.isKinematic = false;
    }
}
