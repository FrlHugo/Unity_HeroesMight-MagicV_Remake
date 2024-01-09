using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    [Space(20)]

    [Header("Ressources of the player")]
    [Space(10)] 
    public int gold = 1000;
    public int wood = 1000;
    public int ore = 1000;
    public int gems = 1000;
    public int crystal = 1000;
    public int sulfur = 1000;
    public int mercury = 1000;

    public UI_Ressources UI_Ressources = null;
   

    // Start is called before the first frame update
    void Start()
    {
        if(UI_Ressources == null)
        {UI_Ressources = FindObjectOfType<UI_Ressources>();}
        
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

    /*
     * Function to add an amount to a ressource
     */
    public void PlayerAddGold(int addAmount)
    { 
        gold += addAmount;
        UI_Ressources.UpdateUI();
    }

    public void PlayerAddWood(int addAmount)
    { wood += addAmount; UI_Ressources.UpdateUI(); }

    public void PlayerAddOre(int addAmount)
    { ore += addAmount; UI_Ressources.UpdateUI(); }

    public void PlayerAddGems(int addAmount)
    { gems += addAmount; UI_Ressources.UpdateUI(); }

    public void PlayerAddCrystal(int addAmount)
    { crystal += addAmount; UI_Ressources.UpdateUI(); }

    public void PlayerAddSulfur(int addAmount)
    { sulfur += addAmount; UI_Ressources.UpdateUI(); }

    public void PlayerAddMercury(int addAmount)
    { mercury += addAmount; UI_Ressources.UpdateUI(); }

    /*
     * Function to reduce a ressources amount 
     * Return false if the substraction is not possible
     */

    public bool PlayerSubstactWood(int subAmount)
    {
        if(PlayerHaveEnoughtWood(subAmount))
        {
            wood -= subAmount;
            UI_Ressources.UpdateUI();
            return true;
        }
        return false;
    }

    public bool PlayerSubstactGold(int subAmount)
    {
        if (PlayerHaveEnoughtGold(subAmount))
        {
            gold -= subAmount;
            UI_Ressources.UpdateUI();
            return true;
        }
        return false;
    }
    public bool PlayerSubstactOre(int subAmount)
    {
        if (PlayerHaveEnoughtOre(subAmount))
        {
            ore -= subAmount;
            UI_Ressources.UpdateUI();
            return true;
        }
        return false;
    }
    public bool PlayerSubstactGems(int subAmount)
    {
        if (PlayerHaveEnoughtGems(subAmount))
        {
            gems -= subAmount;
            UI_Ressources.UpdateUI();
            return true;
        }
        return false;
    }
    public bool PlayerSubstactCrystal(int subAmount)
    {
        if (PlayerHaveEnoughtCrystal(subAmount))
        {
            crystal -= subAmount;
            UI_Ressources.UpdateUI();
            return true;
        }
        return false;
    }
    public bool PlayerSubstactSulfur(int subAmount)
    {
        if (PlayerHaveEnoughtSulfur(subAmount))
        {
            sulfur -= subAmount;
            UI_Ressources.UpdateUI();
            return true;
        }
        return false;
    }
    public bool PlayerSubstactMercury(int subAmount)
    {
        if (PlayerHaveEnoughtMercury(subAmount))
        {
            mercury -= subAmount;
            UI_Ressources.UpdateUI();
            return true;
        }
        return false;
    }
    /*
     * Function use to check if the player got enought of one ressources.
     */
    public bool PlayerHaveEnoughtWood(int amount)
    {
        if(wood >= amount)
        {
    
            return true;
        }
        return false;

    }
    public bool PlayerHaveEnoughtGold(int amount)
    {
        if (gold >= amount)
        {
            return true;
        }
        return false;

    }
    public bool PlayerHaveEnoughtOre(int amount)
    {
        if (ore >= amount)
        {
            return true;
        }
        return false;

    }
    public bool PlayerHaveEnoughtGems(int amount)
    {
        if (gems >= amount)
        {
            return true;
        }
        return false;

    }
    public bool PlayerHaveEnoughtCrystal(int amount)
    {
        if (gems >= amount)
        {
            return true;
        }
        return false;

    }
    public bool PlayerHaveEnoughtSulfur(int amount)
    {
        if (gems >= amount)
        {
            return true;
        }
        return false;

    }
    public bool PlayerHaveEnoughtMercury(int amount)
    {
        if (gems >= amount)
        {
            return true;
        }
        return false;

    }



}
