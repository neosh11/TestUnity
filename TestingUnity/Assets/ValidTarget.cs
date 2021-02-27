using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidTarget : MonoBehaviour
{
    public enum TypeOfObject
    {
        Base = 0,
        Note = 1,
    }
    public TypeOfObject type = TypeOfObject.Base;
    // Start is called before the first frame update

    public void ReactToHit(Vector3 location)
    {

        // Add note here
        if (type == TypeOfObject.Base)
        {
            CreateNote(location);
        }
        if (type == TypeOfObject.Note)
        {
            // Display note information
            DisplayNote(this.transform.gameObject.GetComponent<Note>());
        }
    }

    private void CreateNote(Vector3 pos)
    {
        Messenger<Vector3>.Broadcast(GameEvent.NOTE_CREATE, pos);
    }

    private void DisplayNote(Note note)
    {
        Messenger<Note>.Broadcast(GameEvent.DISPLAY_NOTE, note);
    }
}
