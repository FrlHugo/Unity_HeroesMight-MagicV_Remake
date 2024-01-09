using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class UI_Ressources : MonoBehaviour
{

    [Header("Player")]

    public GameObject localPlayer;

    [Space(10)]
    [Header("txt Ressources")]
    public TMP_Text txtWood;
    public TMP_Text txtGold;
    public TMP_Text txtOre;
    public TMP_Text txtGems;
    public TMP_Text txtCrystal;
    public TMP_Text txtSulfur;
    public TMP_Text txtMercury;

    // Start is called before the first frame update
    void Start()
    {
        localPlayer = GameObject.FindGameObjectsWithTag("Player_Team1")[0];

        localPlayer.GetComponent<Player>().UI_Ressources = this;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI()
    {
        //get player's wood value and pass it into the text mesh pro component as text
        
        txtWood.text = localPlayer.GetComponent<Player>().wood.ToString();
      
        txtGold.text = localPlayer.GetComponent<Player>().gold.ToString();

        txtOre.text = localPlayer.GetComponent<Player>().ore.ToString();

        txtGems.text = localPlayer.GetComponent<Player>().gems.ToString();

        txtCrystal.text = localPlayer.GetComponent<Player>().crystal.ToString();

        txtSulfur.text = localPlayer.GetComponent<Player>().sulfur.ToString();

        txtMercury.text = localPlayer.GetComponent<Player>().mercury.ToString();
       
    }


}
