using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Sc : MonoBehaviour
{
    public static int idx = 0;
    int tmr;
    
    void Update()
    {
        if(idx == 2)
        {
            if(Text_Sc.shot10Times >= 10)
            {
                tmr ++;
            }
            if(tmr == 20){
                tmr = 0;idx = 3;
            }
        }

        if(idx == 3)
        {
            if(Text_Sc.maxShot >= 1 && Text_Sc.minShot >= 1)
            {
                tmr ++;
            }
            if(tmr == 20)
            {tmr = 0;idx = 4;}
        }

        if(idx == 4)
        {
            if(Text_Sc.point0 >= 1 && Text_Sc.point1 >= 1 && Text_Sc.point2 >= 1 && Text_Sc.point3 >= 1)
            {
                tmr ++;
            }
            if(tmr == 20)
            {tmr = 0;idx = 5;}
        }

        if(idx == 5)
        {
            if(SlotManager_Sc.slotCount >= 1)
            {
                tmr ++;
            }
            if(tmr == 20)
            {tmr = 0;idx = 6;}
        }

        if(idx == 6)
        {
            if(SlotManager_Sc.successCount >= 1)
            {
                tmr ++;
            }
            if(tmr == 20)
            {tmr = 0;idx = 7;}
        }

        if(2 < idx && idx < 7)
        {
            if(Shooting_Sc.shotCount == 0)
            {
                Shooting_Sc.shotCount = 20;
            } 
        }
    }
}
