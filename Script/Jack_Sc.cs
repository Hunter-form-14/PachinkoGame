using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jack_Sc : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject,5.0f);

        if(GameManager_Sc.idx < 5){return;}

        SlotManager_Sc.slotCount ++;
    }
}
