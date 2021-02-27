using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EditNotePopUp : MonoBehaviour
{
    [SerializeField] private TMP_InputField noteText;
    private Note note;
    public void Open(Note note)
    {
        gameObject.SetActive(true);
        CursorControls.ConfineCursor();
        noteText.text = note.GetText();
        this.note = note;
    }
    public void Close()
    {
        noteText.text = "";
        CursorControls.NoCursor();
        gameObject.SetActive(false);
    }


    public void OnSubmit()
    {
        note.SetText(noteText.text);
        // Close
        Close();
    }


}
