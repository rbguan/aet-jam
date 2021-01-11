using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BoatCounter : MonoBehaviour
{

    public Text counter;
    private int numDeadBoats = 0;
    [HideInInspector]
    public int numBoatsStart;
    void Start()
    {
        counter.text = "Boats Left To Yeet: " + (numBoatsStart - numDeadBoats);
    }

    public void anotherBoatYeeted()
    {
        numDeadBoats++;
        counter.text = "Boats Left To Yeet: " + (numBoatsStart - numDeadBoats);
        if(numDeadBoats == numBoatsStart)
        {
            SceneManager.LoadScene("OutroDialogScene");
        }
    }
}
