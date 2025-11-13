using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotR_Sc : MonoBehaviour
{
    public float slotRSpeed = -4.5f;
    public float stopSpeedR = 0.1f;
    int rotateTimesR;
    float currentXAngle;

    public static float slotRXAngle;
    public static bool is_stopR;

    int tmrR = 0;

    void Start(){
        rotateTimesR = (int)(1 / stopSpeedR) + 1;
    }
    
    // Update is called once per frame
    void Update()
    {
        Rotating();
        StopSlot();

        if(SlotManager_Sc.phase == 0){tmrR = 0;}
    }

    void Rotating()
    {
        if(SlotManager_Sc.phase > 3 || SlotManager_Sc.phase == 0){return;}

        this.transform.Rotate(0,0,slotRSpeed);
    }

    void StopSlot()
    {
        if(SlotManager_Sc.phase != 4){return;}

        if(tmrR == 0)
        {currentXAngle = this.transform.eulerAngles.z;}

        if(1 <= tmrR && tmrR <= rotateTimesR)
        {this.transform.Rotate(0,0,(-currentXAngle % 45) * stopSpeedR);}

        if(tmrR == 11)
        {
            slotRXAngle = this.transform.eulerAngles.z;
            is_stopR = true;
        }

        tmrR ++;
    }
}