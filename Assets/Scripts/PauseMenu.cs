using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    // Start is called before the first frame update
    public static bool isPaused;
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Pause();
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Unpause();
    }

    public void ReturnToMainMenu()
    {
        Unpause();
        SceneManager.LoadScene("MainMenu");
    }

    public void ResetGame()
    {
        Unpause();
        SceneManager.LoadScene("Game");
    }

    private void Unpause()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }
}
