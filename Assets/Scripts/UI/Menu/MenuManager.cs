using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MenuManager : MonoBehaviour
{
    public GameObject Panel_MenuPrincipal;
    public GameObject Panel_Options;
    public GameObject Panel_QuitConfirm;
    // Start is called before the first frame update
    void Start()
    {
        Panel_MenuPrincipal.SetActive(true);
        Panel_Options.SetActive(false);
        Panel_QuitConfirm.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            WantToQuitGame();
        }
    }

    public void CreateGame()
    {
        SceneManager.LoadSceneAsync("Campagne01");
    }

    public void OpenOptions()
    {

        Panel_MenuPrincipal.SetActive(false);
        Panel_Options.SetActive(true);
    }

    public void CloseOptions()
    {
        Panel_MenuPrincipal.SetActive(true);
        Panel_Options.SetActive(false);
    }

    public void WantToQuitGame()
    {
        Panel_MenuPrincipal.SetActive(false);
        Panel_QuitConfirm.SetActive(true);
    }

    public void QuitGameYes()
    {
        Application.Quit();
    }

    public void QuitGameNo()
    {
        Panel_MenuPrincipal.SetActive(true);
        Panel_QuitConfirm.SetActive(false);
    }
}
