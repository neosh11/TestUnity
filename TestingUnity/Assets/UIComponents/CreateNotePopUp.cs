using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreateNotePopUp : MonoBehaviour
{


    // Fields in order to clear them after submit
    [SerializeField] private TMP_InputField noteText;

    private Vector3 position;
    private string text;
    public void OnEndNote()
    {
        this.text = noteText.text;
    }

    public void OnSubmit()
    {
        NoteManger.CreateNote(text, position);
        // Close
        Close();
    }

    public void Open(Vector3 pos)
    {
        CursorControls.ConfineCursor();
        this.position = pos;
        gameObject.SetActive(true);
    }
    public void Close()
    {
        noteText.text = "";

        CursorControls.NoCursor();
        gameObject.SetActive(false);
    }
}
