using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManger : MonoBehaviour
{

    [SerializeField] private static GameObject notePrefab;
    [SerializeField] private static List<GameObject> notesObj;
    private static List<Note> notes;
    // Start is called before the first frame update

    public static void CreateNote(string text, Vector3 position)
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
            notesObj.Add(note);
            notes.Add(target);
        }
        else
        {
            // something is wrong, remove note
            Debug.Log("could not create note, component not found");
            Destroy(note);
        }
    }

    public static void CreateNote(NoteData n)
    {
        CreateNote(n.text, n.position);
    }

    public static List<Note> GetNotes()
    {
        return notes;
    }

    public static void SetNotes(List<NoteData> n)
    {
        // destroy all notes
        notesObj.ForEach(delegate (GameObject g)
        {
            Destroy(g);
        });
        notesObj = new List<GameObject>();
        notes = new List<Note>();


        n.ForEach(delegate (NoteData nd)
        {
            CreateNote(nd);
        });
    }

    void Start()
    {
        Debug.Log("jelly");
        // Init prefab
        notePrefab = (GameObject)Resources.Load("Note");
        // Initialize list

        if (notesObj == null)
        {
            notesObj = new List<GameObject>();
            notes = new List<Note>();
        }
        else if (notesObj.Count > 0 && (notesObj[0] == null || !notesObj[0].scene.IsValid()))
        {
            Debug.Log("Removing all Items");
            {
                // If gameobject does not exist
                notesObj.ForEach(delegate (GameObject g)
                {
                    Destroy(g);
                });
                notesObj = new List<GameObject>();
                notes = new List<Note>();

            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
