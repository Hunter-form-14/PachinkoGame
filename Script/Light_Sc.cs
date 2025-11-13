using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Sc : MonoBehaviour
{
    Color lightColor;
    int changeTmr;

    // Start is called before the first frame update
    void Start()
    {
        lightColor = this.GetComponent<Light>().color;
    }

    void Update()
    {
        if(SlotManager_Sc.phase != 5)
        {changeTmr = 0;}
    }

    public void ChangeLight()
    {
        this.GetComponent<Light>().color = lightColor;

        if(changeTmr == 0)
        {lightColor = new Color(1.0f,0.0f,0.0f,1.0f);}

        if(changeTmr == 20)
        {lightColor = new Color(0.0f,1.0f,1.0f,1.0f);}

        if(changeTmr == 40)
        {lightColor = new Color(1.0f,0.0f,1.0f,1.0f);}

        if(changeTmr == 60)
        {lightColor = new Color(1.0f,1.0f,0.0f,1.0f);}

        if(changeTmr == 80)
        {lightColor = new Color(0.0f,0.0f,1.0f,1.0f);}

        if(changeTmr == 100)
        {lightColor = new Color(1.0f,1.0f,1.0f,1.0f);}

        changeTmr ++;
    }
}
