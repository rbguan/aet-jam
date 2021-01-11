using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BoatCounter : MonoBehaviour
{

    public Text counter;
    [SerializeField]
    private float postWinWait;
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
            StartCoroutine("BoatSceneWon");
        }
    }

    private IEnumerator BoatSceneWon()
    {
        yield return new WaitForSeconds(postWinWait);
        SceneManager.LoadScene("OutroDialogScene");
    }
}
