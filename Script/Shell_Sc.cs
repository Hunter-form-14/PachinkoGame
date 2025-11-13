using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell_Sc : MonoBehaviour
{
    // public AudioClip sound1;
    // AudioSource hitAudio;
    private int tmr = 0;

    void Start()
    {
        // hitAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (tmr != 20)
        {
            tmr += 1;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = this.transform.GetComponent<Rigidbody>();
        float positionY = this.transform.position.y;

        // if (tmr == 20 && rb.velocity.magnitude > 0.8f && positionY > 12.4f)
        // {
        //     hitAudio.PlayOneShot(sound1);
        // }
    }
}
