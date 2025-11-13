using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Sc : MonoBehaviour
{
    public float speed = 3.6f;

    // Update is called once per frame
    void Update()
    {
        if(GameManager_Sc.idx < 2){return;}
    
        Transform myTransform = this.transform;

        myTransform.Rotate(speed,0,0,Space.World);
    }
}
