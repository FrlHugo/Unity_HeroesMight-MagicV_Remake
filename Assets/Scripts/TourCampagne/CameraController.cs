using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class CameraController : MonoBehaviour
{
    [Space(0)]    
    [Header("Camera Settings")]    
    [Space(10)]

    [SerializeField] private float cameraSpeed = 1f;
    public GameObject playerCamera;

    [Space(0)]    
    [Header("Keyboard Movement")]    
    [Space(5)]

    [SerializeField] private Vector3 vectorMoveInput;
    [SerializeField] private Vector3 vectorMoveInputM;
    [SerializeField] private Vector2 cameraBorderKeyboard = new Vector2(100f, 100f);

    [Space(10)]    
    [Header("Mouse Mouvement")]    
    [Space(5)]

    [SerializeField] private float mouseMouvementBorderthickness = 10f;
    [SerializeField] private float cameraMovementSmoothing = 5f;

    [Space(10)]    
    [Header("Mouse Rotation")]    
    [Space(5)]

    [SerializeField] private float targetSpringArmAngleX;
    [SerializeField] private float targetCameraAngleY;
    [SerializeField] private float currentSpringArmAngleX;
    [SerializeField] private float currentCameraAngleY;

    [SerializeField] private float cameraRotationSpeed;
    [SerializeField] private float cameraRotationXMin = 20f;
    [SerializeField] private float cameraRotationXMax = 70f;

    [SerializeField] private int width = Screen.width; // largeur
    [SerializeField] private int height = Screen.height; // hauteur
    [SerializeField] private int heightBoundary = 5;
    [SerializeField] private int widthBoundary = 5;

    [Space(10)]    
    [Header("Spring Arm Zoom")]    
    [Space(5)]

    [SerializeField] private GameObject springArm;
    [SerializeField] private float springArmLenght = 10;
    [SerializeField] private float zoomInput;
    [SerializeField] private float springArmLenghtMin = 2;
    [SerializeField] private float springArmLenghtMax = 15;

    private float zoomSpeed = 200f;
    float xM = 0;
    float zM = 0f;

    private void Awake()
    {
        //rotation right and left camera with player
        targetCameraAngleY = transform.eulerAngles.y;
        currentCameraAngleY = targetCameraAngleY;

        //rotation up and down with the spring arm
        targetSpringArmAngleX = springArm.transform.eulerAngles.x;
        currentSpringArmAngleX = targetSpringArmAngleX;

        width = Screen.width; // largeur
        height = Screen.height; // hauteur
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        HandleKeyboardInput();
        CameraMoveKeyboard();

        HandleKeyboardRotationInput();
        CameraRotationY();

        HandleZoomInput();
        CameraZoom();
        
        CameraMoveMouse();

        
    }

    /// <summary>
    /// function than handle the keyboard input for the camera movement
    /// </summary>
    private void HandleKeyboardInput()
    {
 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 right = transform.right * x;
        Vector3 forward = transform.forward * z;

        vectorMoveInput = (forward + right).normalized;
    }

    /// <summary>
    /// Camera Mouvement with the keyboard
    /// </summary>
    public void CameraMoveKeyboard()
    {
        Vector3 nextPosition = transform.position;
        nextPosition = transform.position + vectorMoveInput * cameraSpeed * Time.deltaTime;

        transform.position = Vector3.Lerp(transform.position, nextPosition, cameraMovementSmoothing);

    }

    /// <summary>
    /// function than handle the keyboard rotation input
    /// </summary>
    private void HandleKeyboardRotationInput()
    {
        if (!Input.GetMouseButton(2))
        {

            targetCameraAngleY += Input.GetAxisRaw("CameraRotationXAxis") * cameraRotationSpeed * Time.deltaTime;

            targetSpringArmAngleX += Input.GetAxisRaw("CameraRotationYAxis") * cameraRotationSpeed * Time.deltaTime;

            targetSpringArmAngleX = Mathf.Clamp(targetSpringArmAngleX, cameraRotationXMin, cameraRotationXMax);

            Cursor.lockState = CursorLockMode.None;
            return;
        }
        Cursor.lockState = CursorLockMode.Locked;

        targetCameraAngleY += Input.GetAxisRaw("Mouse X") * cameraRotationSpeed * Time.deltaTime;

        targetSpringArmAngleX += Input.GetAxisRaw("Mouse Y") * cameraRotationSpeed * Time.deltaTime;

        targetSpringArmAngleX = Mathf.Clamp(targetSpringArmAngleX, cameraRotationXMin, cameraRotationXMax);
    }

    /// <summary>
    /// rotate the camera on two axis
    /// </summary>
    private void CameraRotationY()
    {
        //player rotation
        currentCameraAngleY = targetCameraAngleY;
        transform.rotation = Quaternion.Euler(0, currentCameraAngleY, 0);

        //spring arm rotation
        currentSpringArmAngleX = targetSpringArmAngleX;
        springArm.transform.localRotation = Quaternion.Euler(currentSpringArmAngleX, 0, 0);
    }

    private void HandleZoomInput()
    {
        zoomInput = Input.GetAxisRaw("Mouse ScrollWheel");
    }

    private void CameraZoom()
    {
        springArmLenght += zoomInput * zoomSpeed * Time.deltaTime;

        springArmLenght = Mathf.Clamp(springArmLenght, springArmLenghtMin, springArmLenghtMax);

        playerCamera.transform.localPosition = new Vector3(0, 0, - springArmLenght);

    }


    /// <summary>
    /// Camera Mouvement with the mouse and the screen size 
    /// </summary>
    public void CameraMoveMouse()
    {
        xM += Input.GetAxisRaw("Mouse X"); 
        zM += Input.GetAxis("Mouse Y"); 

        if (Input.mousePosition.x > width - widthBoundary || Input.mousePosition.x < widthBoundary) 
        {
            
        }
        else
        {
            xM = 0; 
        }

        if (Input.mousePosition.y > height - heightBoundary || Input.mousePosition.y < heightBoundary )
        {
     
        }
        else
        {
            zM = 0;
        }

        Vector3 rightM = transform.right * xM;
        Vector3 forwardM = transform.forward * zM;

        vectorMoveInputM = (forwardM + rightM).normalized;

        Vector3 nextPositionM = transform.position;

        nextPositionM = transform.position + vectorMoveInputM * cameraSpeed * Time.deltaTime;

        transform.position = Vector3.Lerp(transform.position, nextPositionM, cameraMovementSmoothing);

    }




}
