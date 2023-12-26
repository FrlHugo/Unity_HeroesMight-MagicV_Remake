using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Army> listArmy = new List<Army>();
    public List<Town> listTown = new List<Town>();

    private Army selectedUnit = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Mouse0))
       {/*
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
                if(selection.GetType() is Army)
                {
                    selectedUnit = selection;
                }
           } */
       }
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
