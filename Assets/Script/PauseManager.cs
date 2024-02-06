using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    bool isGamePaused = false;
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        isGamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isGamePaused) {
                Pause();
            }
            else if (isGamePaused)
            {
                Resume();
            }
        }

    }

    void Pause()
    {
        pausePanel.SetActive(true);
        isGamePaused = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        isGamePaused = false;
        Time.timeScale = 1;
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
