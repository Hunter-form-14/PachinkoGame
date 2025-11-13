using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon_Sc : MonoBehaviour
{ 
    public float rotationSpeed = 0.9f;
    private int tmr = 1;
    float XAngle;

    // Update is called once per frame
    void Update()
    {
        if(GameManager_Sc.idx == 0 || GameManager_Sc.idx == 1){return;}

        XAngle = transform.eulerAngles.x;
        
        if (XAngle > 180)
        {
            XAngle = XAngle - 360;
        }
    
        if (XAngle > 45)
        {
            tmr = 2;
        }
        if (XAngle < -45)
        {
            tmr = 1;
        }
        if (tmr == 1)
        {
            transform.Rotate (new Vector3(rotationSpeed,0,0));
        }
        if (tmr == 2)
        {
            transform.Rotate (new Vector3(-1 * rotationSpeed,0,0));
        }
    }
}
