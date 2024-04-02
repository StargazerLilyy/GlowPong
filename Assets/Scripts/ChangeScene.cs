using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void QuitSequence()
    {
        Application.Quit();
    }

    public void StartSinglePlayer(int sceneID)
    {
        GlobalSettings.singlePlayer = true;
        MoveToScene(sceneID);
    }

    public void StartMultiPlayer(int sceneID)
    {
        GlobalSettings.singlePlayer = false;
        MoveToScene(sceneID);
    }
}
