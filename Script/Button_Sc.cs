using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Sc : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource pushAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        pushAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager_Sc.idx < 6){return;}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(0,-0.03f,0);
            pushAudio.PlayOneShot(sound1);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            transform.Translate(0,0.03f,0);
        }
    }
}
