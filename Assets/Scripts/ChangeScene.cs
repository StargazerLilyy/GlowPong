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

    public void GoToSelectDifficulty(int sceneID)
    {
        MoveToScene(sceneID);
    }

    public void StartSinglePlayer(int selectedDifficulty)
    {
        switch (selectedDifficulty)
        {
            case 1:
                GlobalSettings.singlePlayerDifficulty = AIDifficulty.Easy;
                break;
            case 2:
                GlobalSettings.singlePlayerDifficulty = AIDifficulty.Medium;
                break;
            case 3:
                GlobalSettings.singlePlayerDifficulty = AIDifficulty.Hard;
                break;
            default:
                break;
        }
        GlobalSettings.singlePlayer = true;
        MoveToScene(1);
    }

    public void StartMultiPlayer(int sceneID)
    {
        GlobalSettings.singlePlayer = false;
        MoveToScene(sceneID);
    }
}
