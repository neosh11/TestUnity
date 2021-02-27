using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayNotePopUp : MonoBehaviour
{
    [SerializeField] private TMP_Text noteText;
    private Note note;
    public void OnSubmit()
    {
        // Close
        noteText.text = "";
        Close();
    }

    public void OnEdit()
    {
        Debug.Log("HEEL");
        // Close current popup and open edit pop up
        noteText.text = "";
        Close();
        // Send signal to open display editnote
        Messenger<Note>.Broadcast(GameEvent.EDIT_NOTE, note);
    }


    public void Open(Note note)
    {
        this.note = note;
        gameObject.SetActive(true);
        CursorControls.ConfineCursor();
        noteText.text = note.GetText();
    }
    public void Close()
    {
        noteText.text = "";
        CursorControls.NoCursor();
        gameObject.SetActive(false);
    }


}
