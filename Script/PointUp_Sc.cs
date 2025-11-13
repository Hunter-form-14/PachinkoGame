using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointUp_Sc : MonoBehaviour
{
    public int point;

    void OnTriggerEnter(Collider other)
    {
        Shooting_Sc.shotCount += point;
        Destroy(other.gameObject);

        if(GameManager_Sc.idx == 4)
        {
            if(point == 3)
            {Text_Sc.point3 ++;}
            if(point == 2)
            {Text_Sc.point2 ++;}
            if(point == 1)
            {Text_Sc.point1 ++;}
            if(point == 0)
            {Text_Sc.point0 ++;}
        }
    }
}
