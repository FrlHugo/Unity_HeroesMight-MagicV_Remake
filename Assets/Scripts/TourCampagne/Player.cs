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

}
