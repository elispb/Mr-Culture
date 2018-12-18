using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotVent : SwitchableDevice {

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool("isSwitchedOn", true);
	}
	
	// Update is called once per frame
	void Update () {
        if(isSwitchedOn)
            anim.SetBool("isSwitchedOn", true);
        else
            anim.SetBool("isSwitchedOn", false);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (isSwitchedOn && other.gameObject.CompareTag("Player"))
        {
            Vector3 theScale = other.attachedRigidbody.transform.localScale;
            if (theScale.y > 0.1f)
            {
                theScale.x *= 0.99f;
                theScale.y *= 0.99f;
                other.attachedRigidbody.transform.localScale = theScale;
            }
        }
    }
}
