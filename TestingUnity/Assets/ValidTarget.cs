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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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
            Debug.Log("Note " + this.transform.gameObject.GetComponent<Note>().GetText());

        }
    }

    private void CreateNote(Vector3 pos)
    {
        Messenger<Vector3>.Broadcast(GameEvent.NOTE_CREATE, pos);

    }
}
