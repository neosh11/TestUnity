using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;


[System.Serializable]
public class NoteData
{
    public Vector3 position;
    public string text;
}

public class NoteSaver : SaveableBehavior
{

    // Store the keys we'll be including in the saved game as constants,
    // to avoid problems with typos.

    private const string NOTES = "notes";

    // a value of the desired type, as long as that type is one that
    // Unity already knows how to serialize.
    private T DeserializeValue<T>(JsonData data)
    {
        Debug.Log("dadada " + data.ToJson());
        return JsonUtility.FromJson<T>(data.ToJson());
    }

    // Provides the saved data for this component.
    public override JsonData SavedData
    {
        get
        {
            // Create the JsonData that we'll return to the saved
            // game system
            var final = new JsonData();
            var notesArray = new JsonData();
            NoteManger.GetNotes().ForEach(delegate (Note n)
            {
                Debug.Log(n.GetPosition() + " " + n.GetText());
                NoteData temp = new NoteData();
                temp.position = n.GetPosition();
                temp.text = n.GetText();
                notesArray.Add(JsonMapper.ToObject(JsonUtility.ToJson(temp)));

            });

            // var res = "[" + string.Join(", ", notesArray.Select(s => $"'{s.text}' {s.position}")) + "]";
            // Debug.Log(res);
            Debug.Log(JsonUtility.ToJson(notesArray));
            // Store our position, rotation, and scale

            final[NOTES] = notesArray;

            return final;
        }
    }

    // Given some loaded data, updates the state of the component.
    public override void LoadFromData(JsonData data)
    {
        // We can't assume that the data will contain every piece of
        // data that we store; remember the programmer's adage,
        // 'be strict in what you generate, and forgiving in what
        // you accept.'

        // Accordingly, we test to see if each item exists in the
        // saved data

        // Update position
        if (data.ContainsKey(NOTES))
        {
            // TODO there need to be a more efficient way
            NoteData[] noteDatas = JsonHelper.FromJson<NoteData>("{\r\n    \"Items\": " + data[NOTES].ToJson() + "}");

            List<Note> notes = new List<Note>();
            NoteManger.SetNotes(new List<NoteData>(noteDatas));
        }
    }
}

