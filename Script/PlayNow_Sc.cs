using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNow_Sc : MonoBehaviour
{
    public GameObject tutorialButton;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void OnClick()
    {
        GameManager_Sc.idx = 8;
        Destroy(this.gameObject);
        Destroy(tutorialButton);
    }
}
