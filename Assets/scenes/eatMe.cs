using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eatMe : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
            Vector3 theScale = other.attachedRigidbody.transform.localScale;
            if (theScale.y > 0.1f)
            {
                theScale.x += .2f;
                theScale.y += .2f;
                other.attachedRigidbody.transform.localScale = theScale;
            }
        }
    }
}