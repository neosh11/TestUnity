using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyNote : MonoBehaviour
{
    [SerializeField] private TMP_Text noteText;
    private Note note;
    public void OnClose()
    {
        // Close
        noteText.text = "";
        Close();
    }

    public void OnDelete()
    {
        Destroy(note.gameObject);
        Close();
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
