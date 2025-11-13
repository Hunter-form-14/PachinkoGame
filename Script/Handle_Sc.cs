using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle_Sc : MonoBehaviour
{
    private float handleSpeed = 0.5f;

    public AudioClip sound1;
    AudioSource rotateAudio;
    private int intervalSound;

    // Start is called before the first frame update
    void Start()
    {
        rotateAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager_Sc.idx < 3){return;}

        float currentXAngle = transform.eulerAngles.x;

        if (currentXAngle > 180)
        {
            currentXAngle -= 360;
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (currentXAngle < 45)
            {
                transform.Rotate (new Vector3(handleSpeed,0,0));
                intervalSound += 1;

                if (intervalSound % 10 == 0)
                {
                    rotateAudio.PlayOneShot(sound1);
                }
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (currentXAngle > -45)
            {
                transform.Rotate (new Vector3(-1 * handleSpeed,0,0));
                intervalSound += 1;

                if (intervalSound % 10 == 0)
                {
                    rotateAudio.PlayOneShot(sound1);
                }
            }
        }
        else
        {
            intervalSound = -1;
        }
    }
}
