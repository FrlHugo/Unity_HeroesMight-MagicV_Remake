using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> listPlayer;

    public List<GameObject> listTown;

    public List<GameObject> listArmy;

    public List<listTeam> listEnumTeam;

    /// <summary>
    /// TODO :
    ///     Ajouter le setup des ui maintenant que l'affectation des town et army se fait par le biais des equipes.
    /// </summary>
    /// 



    /// <summary>
    ///On start we affect every town and army to the player based on his team
    /// </summary>
    /// 

    void Start()
    {
        findPlayers();
        findTown();
        findArmy();
        setupTabTeam();

        foreach (var p in listPlayer)
        {
            AffectArmyToPlayer(p.GetComponent<Player>());
            AffectTownToPlayer(p.GetComponent<Player>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// storing every player we can find on the scene 
    /// </summary>
    public void findPlayers()
    {
        foreach(Player p in FindObjectsOfType<Player>())
        {
            listPlayer.Add(p.gameObject);
        }
    }

    /// <summary>
    /// storing every town we can find on the scene
    /// </summary>
    public void findTown()
    {
        foreach (Town p in FindObjectsOfType<Town>())
        {
            listTown.Add(p.gameObject);
        }
    }

    /// <summary>
    /// storing every army we can find on the scene 
    /// </summary>
    public void findArmy() 
    {
        foreach (Army p in FindObjectsOfType<Army>())
        {
            listArmy.Add(p.gameObject);
        }
    }
    /// <summary>
    /// store every enum team in a list
    /// this function contain a foreach for an enum
    /// </summary>
    public void setupTabTeam()
    {
        foreach(listTeam team in Enum.GetValues(typeof(listTeam)))
        {
            listEnumTeam.Add(team);
        }    
    }


    public void AffectArmyToPlayer(Player player)
    {

        foreach(GameObject army in listArmy)
        {
            if(army.GetComponent<Army>().team == player.team)
            {
                player.listArmy.Add(army);
            }
        }
    }

    public void AffectTownToPlayer(Player player)
    {
        foreach (GameObject town in listTown)
        {
            if (town.GetComponent<Town>().team == player.team)
            {
                player.listTown.Add(town);
            }
        }
    }
}
