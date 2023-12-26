using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Army")]
public class Inventory : ScriptableObject
{

    public InventorySlot[] InventoryArmy = new InventorySlot[8]; // inventaire de l'armée 8 unité max 

    public void AddUnit(Unit unit, int amount)
    {
        bool hasUnit = false;
        for(int i = 0; i < InventoryArmy.Length; i++)
        {
            if (InventoryArmy[i].unit == unit)
            {
                InventoryArmy[i].AddAmount(amount);
                hasUnit = true;
                break;
            }
        }
        if(hasUnit)
        {
            for (int i = 0; i < InventoryArmy.Length; i++)
            {
                if (InventoryArmy[i] == null)
                {
                    InventoryArmy[i] = new InventorySlot(unit, amount);
                    break;
                }
            }
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public Unit unit;
    public int amount;


    public InventorySlot(Unit unit, int amount)
    {
        this.unit = unit;
        this.amount = amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }


}
