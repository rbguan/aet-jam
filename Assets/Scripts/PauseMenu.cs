using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject panel;
    public CharacterInteract characterInteract;

    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Time.timeScale = 0f;
                panel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                characterInteract.isPaused = true;
                isPaused = true;
            }
            else
            {
                OnResume();
            }
        }
    }

    public void OnResume()
    {
        panel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        characterInteract.isPaused = false;
        isPaused = false;
    }

    public void OnRetry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnReturn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScene");
        //Cursor.lockState = CursorLockMode.Locked;
    }
}
