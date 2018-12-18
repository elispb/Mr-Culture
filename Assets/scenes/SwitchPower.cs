using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPower : MonoBehaviour {

    public GameObject[] targets;
    public Animator anim;
    private float timeDelay = 5f;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            anim.SetBool("Switch", true);
            Invoke("SwitchOff", timeDelay);
            for (int i = 0; i < targets.Length; i++)
            {
                targets[i].GetComponent<SwitchableDevice>().isSwitchedOn = false;
            }
        }
    }

    void SwitchOff()
    {
        anim.SetBool("Switch", false);
        for (int i = 0; i < targets.Length; i++)
        {            
            targets[i].GetComponent<SwitchableDevice>().isSwitchedOn = true;
        }
    }
}
