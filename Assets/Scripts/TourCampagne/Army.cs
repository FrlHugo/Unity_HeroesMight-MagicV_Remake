using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army : MonoBehaviour
{
    public Inventory inventoryArmy;
    public GameObject selectedEffect;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IsSelected()
    {
        selectedEffect.SetActive(true);
    }

    public void IsUnSelected()
    {
        selectedEffect.SetActive(false);
    }
}
