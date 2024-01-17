using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UIElements;

public class Town : MonoBehaviour
{
    [Header("Army info")]
    [Space(5)]
    
    public listTeam team = listTeam.None;

    [Space(10)]
    [Header("Ui Army")]
    [Space(5)]

    public GameObject Prefab_UI_Panel_Town;
    public GameObject UI_Panel_Town;
    public GameObject UI_HB_ListTown;

    [Space(10)]
    [Header("MiniMap")]
    [Space(5)]

    public GameObject IconMiniMap;

    [Space(10)]
    [Header("Gameplay feedback")]
    [Space(5)]

    public GameObject selectedEffect;


    // Start is called before the first frame update
    void Start()
    {
        //SetupTownUI();

      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Find we find the horizontal box where we are going to add the ui panel of the army
    /// next we instantiate this panel as the horizontal box 's child
    /// then we link this gameobject with the ui to the ui side
    /// </summary>
    public void SetupTownUI()
    {
        UI_HB_ListTown = GameObject.FindGameObjectWithTag("UI_HB_ListTown");
        UI_Panel_Town = Instantiate(Prefab_UI_Panel_Town, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), UI_HB_ListTown.transform);

        UI_Panel_Town.GetComponent<Script_UI_Panel_Town>().town = gameObject;
    }
}
