using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;



public class EscapeMenu : MonoBehaviour
{

    public void OnCancel()
    {
        Close();
    }

    public void OnResetCamera()
    {
        Debug.Log("Not yet done");

        // Check if file exists

        var loadPath = Path.Combine(Application.persistentDataPath, "HelloDarkness1");
        if (File.Exists(loadPath))
        {
            Debug.Log("Attempting to load");
            SavingService.LoadGame("HelloDarkness1");

        }
        else
        {
            Debug.Log("No load found");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        Close();
    }


    public void OnSave()
    {
        Debug.Log("Not yet done");
        SavingService.SaveGame("HelloDarkness1");

        Close();
    }

    public void OnReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");

        Close();
    }


    public void Open()
    {
        gameObject.SetActive(true);
        CursorControls.ConfineCursor();
    }
    public void Close()
    {
        CursorControls.NoCursor();
        gameObject.SetActive(false);
    }
}
