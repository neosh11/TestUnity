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
    [SerializeField] private  DestroyNote destroyNote;
    [SerializeField] private EscapeMenu escapeMenu;



    public void CloseAllMenus()
    {
        displayNotePopUp.Close();
        createNotePopUp.Close();
        editNotePopUp.Close();
        destroyNote.Close();
        escapeMenu.Close();

    }

    // Start is called before the first frame update
    void Start()
    {
        // turn off pop ups at the start of the game
        CloseAllMenus();
    }

    // Update is called once per frame
    void Update()
    {
        notesLabel.text = "Time " + Time.realtimeSinceStartup.ToString();
        fpsLabel.text = "FPS " + ((int)(1.0f / Time.smoothDeltaTime)).ToString();

        // Menu cancelling
        // Escape menu only if no other menu is open
        if (Cursor.lockState == CursorLockMode.Locked && Input.GetButtonDown("Cancel"))
        {
            Messenger.Broadcast(GameEvent.ESCAPE_MENU);
        }
        else if (Input.GetButtonDown("Cancel"))
        {
            // Some menu is open when escape pressed, close menus
            CloseAllMenus();
        }
    }

    void Awake()
    {
        Messenger<Vector3>.AddListener(GameEvent.NOTE_CREATE, OnTargetHit);
        Messenger<Note>.AddListener(GameEvent.DISPLAY_NOTE, onNoteClick);
        Messenger<Note>.AddListener(GameEvent.EDIT_NOTE, onNoteEdit);
        Messenger<Note>.AddListener(GameEvent.DESTROY_NOTE, onDestroyNote);

        Messenger.AddListener(GameEvent.ESCAPE_MENU, onEscapeMenu);
    }
    void OnDestroy()
    {
        Messenger<Vector3>.RemoveListener(GameEvent.NOTE_CREATE, OnTargetHit);
        Messenger<Note>.RemoveListener(GameEvent.DISPLAY_NOTE, onNoteClick);
        Messenger<Note>.RemoveListener(GameEvent.EDIT_NOTE, onNoteEdit);
        Messenger<Note>.RemoveListener(GameEvent.DESTROY_NOTE, onDestroyNote);

        Messenger.RemoveListener(GameEvent.ESCAPE_MENU, onEscapeMenu);
    }

    private void OnTargetHit(Vector3 pos)
    {
        createNotePopUp.Open(pos);
    }
    private void onNoteClick(Note note)
    {
        displayNotePopUp.Open(note);
    }
    private void onNoteEdit(Note note)
    {
        editNotePopUp.Open(note);
    }

    private void onDestroyNote(Note note)
    {
        destroyNote.Open(note);
    }
    private void onEscapeMenu()
    {
        escapeMenu.Open();
    }
}
