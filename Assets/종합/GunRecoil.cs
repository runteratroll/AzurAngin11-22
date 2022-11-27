using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem.XR;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class GunRecoil : MonoBehaviour
{
    public GameObject cinemachine;

    public PlayerRoot Player;
    int mp;

    public bool isRun = false;
    public bool isGun = false;

    public float reTime;
    public float re = 0;

    public float reloadTime;
    public float reload = 0;

    public float recoil = 1;

    void Update()
    {
        RunTime();
        GunTime();

        if (Input.GetMouseButton(0) && isGun == false)
        {
            isGun = true;
            isRun = true;

            re = 0;
            reload = 0;

            mp = Random.Range(0, 2);
            
            St();
        }

        if (Input.GetMouseButton(1))
        {
            Zoom();
        }
        else
        {
            cinemachine.SetActive(false);
        }
    }

    void RunTime()
    {
        if(isRun)
        {
            Debug.Log("Run");
            re += 1 * Time.deltaTime;

            if (re > reTime)
            {
                isRun = false;
                Fi();
            }
        }
        
    }
    void GunTime()
    {
        if (isGun)
        {
            Debug.Log("Gun");
            reload += 1 * Time.deltaTime;
            if (reload > reloadTime)
            {
                isGun = false;
            }
        }
    }

    void St()
    {
        if(mp == 0)
        {
            Player.transform.DORotate(new Vector3(Player.xRotate -= Random.RandomRange(recoil * 1f, recoil * 1.5f),
            Player.yRotate += Random.RandomRange(recoil * 0.5f, recoil * 0.75f), 0), 0.025f);
        }
        if (mp == 1)
        {
            Player.transform.DORotate(new Vector3(Player.xRotate -= Random.RandomRange(recoil * 1f, recoil * 1.5f),
            Player.yRotate -= Random.RandomRange(recoil * 0.5f, recoil * 0.75f), 0), 0.025f);
        }
    }

    void Fi()
    {
        if (mp == 0)
        {
            Player.transform.DORotate(new Vector3(Player.xRotate += Random.RandomRange(recoil * 0.5f, recoil * 0.75f),
            Player.yRotate -= Random.RandomRange(recoil * 0.25f, recoil * 0.375f), 0), 0.05f);
        }
        if (mp == 1)
        {
            Player.transform.DORotate(new Vector3(Player.xRotate += Random.RandomRange(recoil * 0.5f, recoil * 0.75f),
            Player.yRotate += Random.RandomRange(recoil * 0.25f, recoil * 0.375f), 0), 0.05f);
        }
    }

    void Zoom()
    {
        cinemachine.SetActive(true);
    }
}
