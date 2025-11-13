using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotL_Sc : MonoBehaviour
{
    public float slotLSpeed = -2.7f;
    public float stopSpeedL = 0.025f;
    int rotateTimesL;
    float currentXAngle;

    public static float slotLXAngle;
    public static bool is_stopL;

    int tmrL;

    void Start(){
        rotateTimesL = (int)(1 / stopSpeedL) + 1;
    }

    // Update is called once per frame
    void Update()
    {
        Rotating();
        StopSlot();

        if(SlotManager_Sc.phase == 0){tmrL = 0;}
    }

    void Rotating()
    {
        if(SlotManager_Sc.phase != 1){return;}

        this.transform.Rotate(0,0,slotLSpeed);
    }

    void StopSlot()
    {
        if(SlotManager_Sc.phase < 2){return;}

        if(tmrL == 0)
        {currentXAngle = this.transform.eulerAngles.z;}

        if(1 <= tmrL && tmrL <= rotateTimesL)
        {this.transform.Rotate(0,0,(-currentXAngle % 45) * stopSpeedL);}

        if(tmrL == 41)
        {
            slotLXAngle = this.transform.eulerAngles.z;
            is_stopL = true;
        }

        tmrL ++;
    }
}
    