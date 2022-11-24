using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilSnake : MonoBehaviour
{
    [SerializeField] CinemachineImpulseSource screenShake;
    [SerializeField] float powerAmount;

    public void ScreenShake(Vector3 dir)
    {
        screenShake.GenerateImpulseWithVelocity(dir);
        //이건 cinemachineImpulseSource를 공부해야할듯
    }
}
