using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    [SerializeField] private Text notesLabel;
    [SerializeField] private Text fpsLabel;

    [SerializeField] private CreateNotePopUp createNotePopUp;

    // Start is called before the first frame update
    void Start()
    {
        createNotePopUp.Close();
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
    }
    void OnDestroy()
    {
        Messenger<Vector3>.RemoveListener(GameEvent.NOTE_CREATE, OnTargetHit);
    }

    private void OnTargetHit(Vector3 pos)
    {
        createNotePopUp.Open(pos);
        // Onsave
    }
}
