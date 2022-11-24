using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using StarterAssets;
public class ThirdenDash : MonoBehaviour
{
    ThirdPersonController moveScript;
    public float dashSpeed;
    public float dashTime;
    public float dashCoolTime;
    private float startCoolTime;
    private StarterAssetsInputs _input;
    // Start is called before the first frame update
    void Start()
    {
        startCoolTime = Time.time;
        moveScript = GetComponent<ThirdPersonController>();

        _input = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(_input.dash && Time.time > startCoolTime + dashCoolTime )
        {
            startCoolTime = Time.time;
            StartCoroutine(Dash());
        }
        _input.dash = false;
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;

        while(Time.time < startTime + dashTime)
        {

            Debug.Log("대쉬이동");
            moveScript._controller.Move(moveScript.inputDirection * dashSpeed * Time.deltaTime);

            yield return null;
        }
        _input.dash = false;
    }
}
