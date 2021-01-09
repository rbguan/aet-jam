using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PaperCounter : MonoBehaviour
{
    public Text paperText;
    private int numPaper;

    // Start is called before the first frame update
    void Start()
    {
        numPaper = 0;
        paperText.text = "Paper: " + numPaper;
    }

    // Update is called once per frame
    void Update()
    {
        if (numPaper == 150)
            SceneManager.LoadScene("BarrelDialogScene");
    }

    public void AddToCounter(int paperToAdd)
    {
        numPaper += paperToAdd;
        paperText.text = "Paper: " + numPaper;
    }
}
