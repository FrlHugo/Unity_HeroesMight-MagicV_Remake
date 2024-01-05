using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Settings")]
    [Space(10)]

    public float cameraSpeed = 20f;
    public float mouseMouvementBorderthickness = 10f;
    public Vector2 distanceLimit;
    public float scrollSpeed;

    [Space(5)]
    public float cameraRotationSpeed;
    public float cameraRotationXMin = 20f;
    public float cameraRotationXMax = 70f;


    [Header("Spring Arm")]
    public GameObject springArm;
    public float springArmLenght = 10;
    public float springArmLenghtMin = 2;
    public float springArmLenghtMax = 15;

    private float zoomSpeed = 200f;

    float rotationX;
    float rotationY;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        rotationX = springArm.transform.localRotation.x;
        rotationY = springArm.transform.localRotation.y;

    }

    // Update is called once per frame
    void Update()
    {
        /* if right click is down
        *  we rotate the spring arm to rotate the camera around with the mouse control  
        */
        if (Input.GetKey(KeyCode.Mouse0))
        {
            print("rotation SprintARM");
            Cursor.lockState = CursorLockMode.Locked;
            CameraRotationMouse();
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            CameraMouveKeyboard();
        }
        CameraZoomWheel();
    }


    /*
     * Camera Mouvement with the axis and the scroll with the mouse wheel
     */
    public void CameraMouveKeyboard()
    {
        Vector3 pos = springArm.transform.position;

        pos.z += Input.GetAxis("Vertical") * cameraSpeed * Time.deltaTime;
        pos.x += Input.GetAxis("Horizontal") * cameraSpeed * Time.deltaTime;


        springArm.transform.position = pos;

    }


    public void CameraRotationMouse()
    {
        // x et y 
        // x la hauteur 
        // y autour 

        rotationX += Input.GetAxisRaw("Mouse Y") * cameraRotationSpeed * Time.deltaTime;
    
        rotationY -= Input.GetAxisRaw("Mouse X") * cameraRotationSpeed * Time.deltaTime;
   
        rotationX = Mathf.Clamp(rotationX, cameraRotationXMin, cameraRotationXMax);

        // Set the rotation to new rotation
        springArm.transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }


    public void CameraZoomWheel()
    {

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        springArmLenght += scroll * Time.deltaTime * zoomSpeed;
        springArmLenght = Mathf.Clamp(springArmLenght, springArmLenghtMin, springArmLenghtMax);

        gameObject.transform.localPosition = new Vector3(0, 0, -springArmLenght);
    }

    public void MovingCameraTo(Vector3 destination)
    {

    }
}
