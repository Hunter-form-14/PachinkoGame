using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotC_Sc : MonoBehaviour
{
    public float slotCSpeed = -3.6f;
    public float stopSpeedC = 0.05f;
    int rotateTimesC;
    float currentXAngle;

    public static float slotCXAngle;
    public static bool is_stopC;

    int tmrC;

    void Start(){
        rotateTimesC = (int)(1 / stopSpeedC) + 1;
    }
    
    // Update is called once per frame
    void Update()
    {
        Rotating();
        StopSlot();

        if(SlotManager_Sc.phase == 0){tmrC = 0;}
    }

    void Rotating()
    {
        if(SlotManager_Sc.phase > 2 || SlotManager_Sc.phase == 0){return;}

        this.transform.Rotate(0,0,slotCSpeed);
    }

    void StopSlot()
    {
        if(SlotManager_Sc.phase < 3){return;}

        if(tmrC == 0)
        {currentXAngle = this.transform.eulerAngles.z;}

        if(1 <= tmrC && tmrC <= rotateTimesC)
        {this.transform.Rotate(0,0,(-currentXAngle % 45) * stopSpeedC);}

        if(tmrC == 21)
        {
            slotCXAngle = this.transform.eulerAngles.z;
            is_stopC = true;
        }

        tmrC ++;
    }
}
