using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Boat> boats;
    public BoatCounter boatCounter;
    void Start()
    {
        foreach(Boat b in boats){
            b.boatCounter = boatCounter;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
