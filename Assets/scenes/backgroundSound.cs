using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundSound : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m") && !GetComponent<AudioSource>().mute)
        {
            GetComponent<AudioSource>().mute = true;
        }
        else if (Input.GetKeyDown("m"))
        {
            GetComponent<AudioSource>().mute = false;
        }

    }
}
