using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting_Sc : MonoBehaviour
{
    public int gravity = 2;

    public GameObject bulletPrefab;

    public static float shotSpeed;
    public static int shotCount = 20;
    public AudioClip sound1;
    AudioSource fireAudio;

    float shotSpeedChange;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3 (0,-1 * gravity,0);
        
        fireAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager_Sc.idx == 7 || GameManager_Sc.idx == 8){return;}
        
        ShotBullet();
        ShotSpeedChange();
    }

    void ShotBullet()
    {
        if(GameManager_Sc.idx < 2){return;}

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (shotCount > 0)
            {
                shotCount -= 1;
                shotSpeed = 1.45f + shotSpeedChange;
                GameObject bullet = (GameObject)Instantiate(bulletPrefab,transform.position,Quaternion.Euler(transform.parent.eulerAngles.x,0,0));
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                bulletRb.AddForce(transform.up * shotSpeed,ForceMode.VelocityChange);
                fireAudio.PlayOneShot(sound1);

                if(GameManager_Sc.idx == 2)
                {
                    Text_Sc.shot10Times ++;
                }

                if(GameManager_Sc.idx == 3)
                {
                    if(shotSpeed >= 1.54f)
                    {Text_Sc.maxShot ++;}
                    if(shotSpeed <= 1.36f)
                    {Text_Sc.minShot ++;}
                }
            }
        }
    }

    void ShotSpeedChange()
    {
        if(GameManager_Sc.idx < 3){return;}

        if (Input.GetKey(KeyCode.W))
        {
            if (shotSpeedChange < 0.09f)
            {
                shotSpeedChange += 0.001f;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (shotSpeedChange > -0.09f)
            {
                shotSpeedChange -= 0.001f;
            }
        }
    }
}
