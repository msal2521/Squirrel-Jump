using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject PausePanel, PauseButton;
    private void Awake()
    {
        Time.timeScale = 1;

        Screen.autorotateToPortrait = false;

        Screen.autorotateToPortraitUpsideDown = false;

        Screen.autorotateToLandscapeLeft = true;

        Screen.autorotateToLandscapeRight = true;

        Screen.orientation = ScreenOrientation.AutoRotation;
    }


    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause()
    {
        PauseButton.SetActive(false);
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        PauseButton.SetActive(true);
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}
