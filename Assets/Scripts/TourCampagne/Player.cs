using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Camera Settings")]
    [Space(10)]

    public float cameraSpeed = 20f;
    public float mouseMouvementBorderthickness = 10f;
    public Vector2 distanceLimit;
    public float scrollSpeed;

    

    public GameObject Camera;

    [Space(20)]
    [Header("In Game")]
    [Space(10)]

    public List<Army> listArmy = new List<Army>();
    public List<Town> listTown = new List<Town>();
    public EnumTeam team;
    private Army selectedUnit = null;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraMouvement();
    } 


    public void SelectUnit(Army newUnit)
    {
        if(selectedUnit == null)
        {
            UnSelectUnit();
        }
        selectedUnit = newUnit;
        selectedUnit.IsSelected(); 
    }

    public void UnSelectUnit()
    {
        selectedUnit.IsUnSelected();
        selectedUnit = null;
    }



    public void CameraMouvement()
    {
        Vector3 pos = Camera.transform.position;

        if(Input.GetKeyDown(KeyCode.Z) || Input.mousePosition.y >= Screen.height - mouseMouvementBorderthickness)
        {
            pos.z += cameraSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.mousePosition.y >=  mouseMouvementBorderthickness)
        {
            pos.z -= cameraSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Q) || Input.mousePosition.x >=  mouseMouvementBorderthickness)
        {
            pos.x -= cameraSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.mousePosition.x >= Screen.width - mouseMouvementBorderthickness)
        {
            pos.x += cameraSpeed * Time.deltaTime;
        }


        float scroll = Input.GetAxis("Mouse ScrollWheel");

        pos.y += scroll * scrollSpeed * 100f * Time.deltaTime;

        //pos.x = Mathf.Clamp(pos.x, -distanceLimit.x, distanceLimit.x);

        //pos.z = Mathf.Clamp(pos.z, -distanceLimit.y, distanceLimit.y);


        Camera.transform.position = pos;
    }
}
