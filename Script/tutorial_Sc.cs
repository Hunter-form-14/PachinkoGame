using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial_Sc : MonoBehaviour
{
    public GameObject playNowButton;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void OnClick()
    {
        GameManager_Sc.idx = 1;
        Destroy(this.gameObject);
        Destroy(playNowButton);
    }
}
