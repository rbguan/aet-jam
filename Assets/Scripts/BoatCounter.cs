using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BoatCounter : MonoBehaviour
{

    public Text counter;
    private int numDeadBoats = 0;
    void Start()
    {
        counter.text = "Boats Yeeted: " + numDeadBoats;
    }

    public void anotherBoatYeeted()
    {
        numDeadBoats++;
        counter.text = "Boats Barrels Yeeted: " + numDeadBoats;
    }
}
