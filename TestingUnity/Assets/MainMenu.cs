using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start()
    {
        SavingService.SaveGame("HelloDarkness1");
        CursorControls.ConfineCursor();
    }
    public void onO1()
    {
        // Switch to scene 1
        SceneManager.LoadScene("O1");

    }

    public void onExit()
    {
        Application.Quit();
        Debug.Log("Exiting");
    }

}
