using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    public GameObject credits;

    // Start is called before the first frame update
    void Start()
    {
        credits.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Escape))
        {
            if (credits.activeSelf)
                credits.SetActive(false);
        }
    }

    public void OnPlay()
    {
        SceneManager.LoadScene("PaperDialogScene");
    }

    public void OnCredits()
    {
        credits.SetActive(true);
    }

    public void OnQuit()
    {
        Application.Quit();
    }    
}
