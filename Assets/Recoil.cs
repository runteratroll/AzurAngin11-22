using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Recoil : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] private float Xrecoil;
    [SerializeField] private float Yrecoil;
    [SerializeField] private float Zrecoil;


    [SerializeField] private float snappiness;
    [SerializeField] private float returnSpeed;

    private Vector3 currentRot;
    private Vector3 targetRot;



    private void Update()
    {
        targetRot = Vector3.Lerp(targetRot, Vector3.zero, returnSpeed * Time.deltaTime); //������ 0���� �ٽ� ���ƿ;��ϴϱ�
        currentRot = Vector3.Slerp(currentRot, targetRot, snappiness * Time.deltaTime); //�󸶳� ������ ��鸱��
        //transform.rotation = Quaternion.Euler(currentRot);
    }



    //�ѽ�
    public void ShootRecoil()
    {
        targetRot += new Vector3(Random.Range(-Xrecoil, Xrecoil), Random.Range(-Yrecoil, Yrecoil), Zrecoil);
    }



}
