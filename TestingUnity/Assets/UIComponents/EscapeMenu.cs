using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{

    public void OnCancel()
    {
        Close();
    }

    public void OnResetCamera()
    {
        Debug.Log("Not yet done");
        Close();
    }


    public void OnSave()
    {
        Debug.Log("Not yet done");
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
