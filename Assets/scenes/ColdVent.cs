using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdVent : SwitchableDevice {

    private Animator anim;


    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();
        anim.SetBool("isSwitchedOn", true);
    }
	
	// Update is called once per frame
	void Update () {
        if (isSwitchedOn)
            anim.SetBool("isSwitchedOn", true);
        else
            anim.SetBool("isSwitchedOn", false);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (isSwitchedOn && other.gameObject.CompareTag("Player"))
        {
            float theSpeed = other.gameObject.GetComponent<SimplePlatformController>().maxSpeed;
            if (theSpeed > 0.5f)
            {
                theSpeed *= 0.9f;
                other.gameObject.GetComponent<SimplePlatformController>().maxSpeed = theSpeed;
            }
        }
    }
}
