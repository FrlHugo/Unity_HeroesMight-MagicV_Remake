using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using static UnityEditor.PlayerSettings;

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

    private int width = Screen.width; // largeur
    private int height = Screen.height; // hauteur

    public int heightBoundary = 5;
    public int widthBoundary = 5;

    public bool isFollowing = false;
    public bool isMovingTo = false;

    [Header("Spring Arm")]
    public GameObject springArm;
    public float springArmLenght = 10;
    public float springArmLenghtMin = 2;
    public float springArmLenghtMax = 15;

    private float zoomSpeed = 200f;

    float rotationX;
    float rotationY;

    public GameObject followTarget;
    public GameObject destination;

    public Vector3 velocity;
    /// <summary>
    /// TODO : FINIR le deplacement de la camera ( follow + moving to)
    /// </summary>

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
        if(isFollowing && followTarget != null )
        {   
            CameraFollow(followTarget);
        }
        else if (isMovingTo && destination != null)
        {
            MovingCameraTo(destination.transform.position);
        }
        else
        {
            CameraMovingOrRotating();
        }
        CameraZoomWheel();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartMovingTo();
        }

    }

    /// <summary>
    /// function than manage the camera between moving and turning around when the mouse's wheel is clicked
    /// </summary>
    public void CameraMovingOrRotating()
    {
        if (Input.GetKey(KeyCode.Mouse3))
        {
            Cursor.lockState = CursorLockMode.Locked;
            CameraRotationMouse();
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            CameraMoveKeyboard();
            CameraMoveMouse();
        }
    }


    /// <summary>
    /// Camera Mouvement with the keyboard
    /// </summary>
    public void CameraMoveKeyboard()
    {
        Vector3 pos = springArm.transform.position;

        pos.z += Input.GetAxis("Vertical") * cameraSpeed * Time.deltaTime;
        pos.x += Input.GetAxis("Horizontal") * cameraSpeed * Time.deltaTime;


        springArm.transform.position = pos;

    }
    /// <summary>
    /// Camera Mouvement with the mouse and the screen size 
    /// </summary>
    public void CameraMoveMouse()
    {

        Vector3 pos = springArm.transform.position;
        if (Input.mousePosition.x > width - widthBoundary) 
        {
            pos.x += cameraSpeed * Time.deltaTime;
        }
        if(Input.mousePosition.x < widthBoundary)
        {
            pos.x -= cameraSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y > height - heightBoundary)
        {
            pos.z += cameraSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y < heightBoundary)
        {
            pos.z -= cameraSpeed * Time.deltaTime;
        }

        springArm.transform.position = pos;

    }

    /// <summary>
    /// Rotate the camera with the mouse axis when mouse  is pressed 
    /// </summary>
    public void CameraRotationMouse()
    {
        rotationX += Input.GetAxisRaw("Mouse Y") * cameraRotationSpeed * Time.deltaTime;
    
        rotationY -= Input.GetAxisRaw("Mouse X") * cameraRotationSpeed * Time.deltaTime;
   
        rotationX = Mathf.Clamp(rotationX, cameraRotationXMin, cameraRotationXMax);

        // Set the rotation to new rotation
        springArm.transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);
    }

    /// <summary>
    /// Camera zooming with the mouse wheel
    /// </summary>
    public void CameraZoomWheel()
    {

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        springArmLenght += scroll * Time.deltaTime * zoomSpeed;
        springArmLenght = Mathf.Clamp(springArmLenght, springArmLenghtMin, springArmLenghtMax);

        gameObject.transform.localPosition = new Vector3(0, 0, -springArmLenght);
    }

    /// <summary>
    /// Move the camera to a certain destination like a city or an army selected by the UI
    /// </summary>
    /// <param name="destination"></param>
    public void MovingCameraTo(Vector3 destination)
    {
        //springArm.GetComponent<Rigidbody>().MovePosition(destination);
    
        springArm.transform.position = Vector3.SmoothDamp(springArm.transform.position, destination, ref velocity, cameraSpeed);

    }

    public void StartMovingTo()
    {
        isMovingTo = true;
    }

    public void EndMovingTo()
    {
        isMovingTo = false;
        destination = null;
    }


    public void StartFollowing()
    {
        isFollowing = true;

    }

    public void StopFollowing()
    {
        isFollowing = false;
        followTarget = null;

    }
    public void CameraFollow(GameObject target)
    {
        springArm.transform.position = target.transform.position;
    }
}
