using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var loadPath = Path.Combine(Application.persistentDataPath, "HelloDarkness1");
        if (File.Exists(loadPath)) SavingService.LoadGame("HelloDarkness1");
        else SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
