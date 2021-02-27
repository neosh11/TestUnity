using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    [SerializeField] private Text notesLabel;
    [SerializeField] private Text fpsLabel;

    [SerializeField] private CreateNotePopUp createNotePopUp;
    [SerializeField] private DisplayNotePopUp displayNotePopUp;
    [SerializeField] private EditNotePopUp editNotePopUp;

    // Start is called before the first frame update
    void Start()
    {
        // turn off pop ups at the start of the game
        displayNotePopUp.Close();
        createNotePopUp.Close();
        editNotePopUp.Close();

    }

    // Update is called once per frame
    void Update()
    {
        notesLabel.text = "Time " + Time.realtimeSinceStartup.ToString();
        fpsLabel.text = "FPS " + ((int)(1.0f / Time.smoothDeltaTime)).ToString();
    }

    void Awake()
    {
        Messenger<Vector3>.AddListener(GameEvent.NOTE_CREATE, OnTargetHit);
        Messenger<Note>.AddListener(GameEvent.DISPLAY_NOTE, onNoteClick);
        Messenger<Note>.AddListener(GameEvent.EDIT_NOTE, onNoteEdit);
    }
    void OnDestroy()
    {
        Messenger<Vector3>.RemoveListener(GameEvent.NOTE_CREATE, OnTargetHit);
        Messenger<Note>.RemoveListener(GameEvent.DISPLAY_NOTE, onNoteClick);
        Messenger<Note>.AddListener(GameEvent.EDIT_NOTE, onNoteEdit);
    }

    private void OnTargetHit(Vector3 pos)
    {
        createNotePopUp.Open(pos);
        // Onsave
    }
    private void onNoteClick(Note note)
    {
        displayNotePopUp.Open(note);
        // Onsave
    }
    private void onNoteEdit(Note note)
    {
        editNotePopUp.Open(note);
        // Onsave
    }
}
