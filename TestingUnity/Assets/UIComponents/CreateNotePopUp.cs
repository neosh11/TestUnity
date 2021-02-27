using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreateNotePopUp : MonoBehaviour
{

    [SerializeField] private GameObject notePrefab;
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
        // Display object for the tag
        GameObject note = Instantiate(notePrefab) as GameObject;
        note.transform.position = position;
        // BG data
        Note target = note.GetComponent<Note>();


        if (target != null)
        {
            target.SetPosition(position);
            target.SetText(text);
        }
        else
        {
            // something is wrong, remove note
            Debug.Log("could not create note, component not found");
            Destroy(note);
        }


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
