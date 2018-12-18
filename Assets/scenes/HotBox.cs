using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {

    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            Vector3 theScale = other.collider.attachedRigidbody.transform.localScale;
            if (theScale.y > 0.1f)
            {
                theScale.x *= 0.99f;
                theScale.y *= 0.99f;
                other.collider.attachedRigidbody.transform.localScale = theScale;
            }
        }
    }
}

