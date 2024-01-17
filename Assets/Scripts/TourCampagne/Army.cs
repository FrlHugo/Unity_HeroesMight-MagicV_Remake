using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Army : MonoBehaviour
{

    [Header("Army info")]
    [Space(5)]

    public Inventory inventoryArmy;
    public listTeam team = listTeam.None;

    [Space(10)]
    [Header("Ui Army")]
    [Space(5)]

    public GameObject Prefab_UI_Panel_Army;
    public GameObject UI_Panel_Army;
    public GameObject UI_HB_ListArmy;
    public Sprite image;


    [Space(10)]
    [Header("Selected")]
    [Space(5)]

    public bool isSelected;
    public GameObject selectedEffect;

    [Space(10)]
    [Header("MiniMap")]
    [Space(5)]

    public GameObject IconMiniMap;



   
    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;

        //SetupArmyUI();

        SetupMiniMapIcon();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IsSelected()
    {
        selectedEffect.SetActive(true);
        isSelected = true;
    }

    public void IsUnSelected()
    {
        selectedEffect.SetActive(false);
        isSelected = false;
    }


    /// <summary>
    /// Find we find the horizontal box where we are going to add the ui panel of the army
    /// next we instantiate this panel as the horizontal box 's child
    /// then we link this gameobject with the ui to the ui side
    /// </summary>
    public void SetupArmyUI()
    {
        UI_HB_ListArmy = GameObject.FindGameObjectWithTag("UI_HB_ListArmy");

        UI_Panel_Army = Instantiate(Prefab_UI_Panel_Army, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), UI_HB_ListArmy.transform);

        UI_Panel_Army.GetComponent<Script_UI_Panel_Army>().Army = gameObject;

        UI_Panel_Army.GetComponent<Script_UI_Panel_Army>().Image.gameObject.GetComponent<Image>().sprite = image;
    }

    public void SetupMiniMapIcon()
    {
        IconMiniMap.GetComponent<SpriteRenderer>().sprite = image;
    }
}
