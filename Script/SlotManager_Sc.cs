using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager_Sc : MonoBehaviour
{
    public static int slotCount;
    public static int phase;
    public static int successCount;

    int resetTmr;

    public AudioClip falseSound;
    public AudioClip successSound;
    public AudioClip stopSound;

    AudioSource slotAudio;
    bool is_sound;

    // public Light_Sc lightL_Sc;
    public Light_Sc lightC_Sc;
    // public Light_Sc lightR_Sc;

    // Start is called before the first frame update
    void Start()
    {
        slotAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager_Sc.idx < 5){return;}
    
        SlotBegining();

        if(GameManager_Sc.idx < 6){return;}

        SlotRotating();
        SlotResult();
    }

    void SlotBegining()
    {
        if(slotCount >= 1 && phase == 0)
        {
            resetTmr = 0;
            phase = 1;

            if(GameManager_Sc.idx < 7){return;}

            slotCount --;
        }
    }

    void SlotRotating()
    {
        if(1 <= phase && phase <= 3)
        {
            if(Input.GetKeyDown(KeyCode.Space)) 
            {
                if(phase == 3)
                {
                    slotAudio.Stop();
                }

                slotAudio.PlayOneShot(stopSound);
                phase ++;
            }

            if (is_sound == false)
            {
                slotAudio.Play();
                is_sound = true;
            }
        }
    }

    void SlotResult()
    {
        if(SlotL_Sc.is_stopL && SlotC_Sc.is_stopC && SlotR_Sc.is_stopR)
        {phase = 5;}

        if(phase != 5){return;}

        int numLInt = (int)Mathf.Round(SlotL_Sc.slotLXAngle);
        int numCInt = (int)Mathf.Round(SlotC_Sc.slotCXAngle);
        int numRInt = (int)Mathf.Round(SlotR_Sc.slotRXAngle);
        
        if (numLInt == numCInt && numCInt == numRInt)
        {
            // lightL_Sc.ChangeLight();
            lightC_Sc.ChangeLight();
            // lightR_Sc.ChangeLight();

            if (resetTmr == 0)
            {
                Shooting_Sc.shotCount += 10;
                slotAudio.PlayOneShot(successSound);

                if(GameManager_Sc.idx == 6)
                {
                    slotCount = 0;
                    successCount++;
                }
            }
        }
        else
        {
            if (resetTmr == 0)
            {
                slotAudio.PlayOneShot(falseSound);
            }
        }
    
        if (resetTmr == 120)
        {
            SlotL_Sc.is_stopL = false;
            SlotC_Sc.is_stopC = false;
            SlotR_Sc.is_stopR = false;

            phase = 0;
            is_sound = false;
        }

        resetTmr ++;
    }
}
