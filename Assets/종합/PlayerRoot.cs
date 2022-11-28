using UnityEngine;

public class PlayerRoot : MonoBehaviour
{
    public float turnSpeed = 4.0f; // 마우스 회전 속도
    public float moveSpeed = 4.0f; // 이동 속도
    public float sprintSpeed = 7.0f;

    private float yRotateSize;
    public float yRotate;
    private float xRotateSize;
    public float xRotate;

    public Vector3 move;
    public GameObject camPos;
    public StarterAssetsInputs _input;

    private void Awake()
    {
        //_input = GetComponent<StarterAssetsInputs>();
    }

    void Update()
    {
        yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        yRotate = transform.eulerAngles.y + yRotateSize;
        xRotateSize = -Input.GetAxis("Mouse Y") * turnSpeed;
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -70, 70);

        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
        camPos.transform.eulerAngles = new Vector3(0, yRotate, 0);

        move =
            camPos.transform.forward * Input.GetAxis("Vertical") +
            camPos.transform.right * Input.GetAxis("Horizontal");



        if(!_input.dash)
        {

            if (_input.sprint)
            {
                camPos.transform.position += move * sprintSpeed * Time.deltaTime;
                transform.position = camPos.transform.position;
            }
            else
            {
                camPos.transform.position += move * moveSpeed * Time.deltaTime;
                transform.position = camPos.transform.position;
            }
        }
        

     

     
    }


}
