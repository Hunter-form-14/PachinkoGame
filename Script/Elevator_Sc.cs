using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Sc : MonoBehaviour
{
    float y = 0.0f;
    float dy = 0.1f;
    int tmr = 0;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, y, transform.position.z);

        if(tmr > 700){
            tmr = 0;
            dy *= -1;
        }
        y += dy;
        tmr ++;
    }
}

