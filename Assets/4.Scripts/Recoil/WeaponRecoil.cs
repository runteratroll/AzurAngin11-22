using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponRecoil : MonoBehaviour
{
    public Cinemachine.CinemachineFreeLook playerCamera;
    public float verticalRecoil;
    public float duration;


    float time;

    
    public void GenerateRecoil()
    {
        time = duration;
    }


    private void Update()
    {
        if(time > 0) //�����ִ� �ð����� 
        {
            playerCamera.m_YAxis.Value -= ((verticalRecoil/1000 * Time.deltaTime) / duration);
            time -= Time.deltaTime;

            
        }
    }

}
